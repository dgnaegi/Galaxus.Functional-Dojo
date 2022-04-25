using Dojo.API;
using Dojo.DataStorage;
using System.Text.Json;
using Galaxus.Functional;

namespace Dojo.Services;

public class FunctionalResponseService
{
    private readonly ProductApiService _productApiService = new ProductApiService();
    private readonly WarrantyApiService _warrantyApiService = new WarrantyApiService();
    private readonly DenormalizedStorageRepository _repository = new DenormalizedStorageRepository();
    
    public async void StoreDenormalizedProductInformation()
    {
        var products = await GetProducts();
        var productWithWarranties = await GetWarranties(products.Unwrap());
        
        await _repository.StoreDenormalized(productWithWarranties.Unwrap());
    }

    private async Task<Result<List<Product>, string>> GetProducts()
    {
        var response = await _productApiService.GetProducts();
        var content = await response.Content.ReadAsStringAsync();
        var productList = JsonSerializer.Deserialize<List<Product>>(content);
        return productList ?? new List<Product>();
    }
    
    private async Task<Result<List<(Product, Warranty)>, string>> GetWarranties(List<Product> products)
    {
        var productIds = products.Select(p => p.Id).ToList();
        var response = await _warrantyApiService.GetWarrantyDurationForProducts(productIds);
        var content = await response.Content.ReadAsStringAsync();
        var warranties = JsonSerializer.Deserialize<List<Warranty>>(content);
        return warranties == null 
            ? new List<(Product, Warranty)>()
            : products.Select(p => EnrichWithWarranty(p, warranties)).ToList();
    }

    private static (Product, Warranty) EnrichWithWarranty(Product product, List<Warranty> warranties)
    {
        var warranty = warranties.SingleOrDefault(w => w.ProductId == product.Id);

        return warranty == null
            ? (product, new Warranty{ProductId = product.Id, Duration = "No warranty"})
            : (product, warranty);
    }
}