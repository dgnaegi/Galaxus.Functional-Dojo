using Dojo.Services;

Console.WriteLine("-----Non functional approach-----");
var nonFunctionalService = new NonFunctionalResponseService();
nonFunctionalService.StoreDenormalizedProductInformation();


Console.WriteLine("-----Functional approach-----");
var functionalService = new FunctionalResponseService();
functionalService.StoreDenormalizedProductInformation();
