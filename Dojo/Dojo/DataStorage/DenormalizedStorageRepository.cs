namespace Dojo.DataStorage;

public class DenormalizedStorageRepository
{
    public Task StoreDenormalized(List<(Product, Warranty)> productWithWarranties)
    {
        Console.WriteLine($"Stored {productWithWarranties.Count} entities");
        return Task.CompletedTask;
    }
}