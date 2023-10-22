using BuildingBricks.Core;
using BuildingBricks.Product.Services;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

string environment = Environment.GetEnvironmentVariable("AZURE_FUNCTIONS_ENVIRONMENT")!;
string appConfigEndpoint = Environment.GetEnvironmentVariable("AppConfigEndpoint")!;
ConfigServices configServices = new(appConfigEndpoint, environment);

using CosmosClient cosmosClient = new(configServices.CosmosUri, configServices.CosmosKey);
Database database = cosmosClient.GetDatabase(configServices.ProductCosmosDatabaseId);

MerchandiseByAvailabilityServices merchandiseByAvailabilityServices = new(configServices, database.GetContainer(configServices.ProductsByAvailabilityContainerId));
MerchandiseByThemeServices merchandiseByThemeServices = new(configServices, database.GetContainer(configServices.ProductsByThemeContainerId));

IHost host = new HostBuilder()
	.ConfigureFunctionsWorkerDefaults()
	.ConfigureServices(s =>
	{
		s.AddSingleton((s) => { return configServices; });
		s.AddSingleton((s) => { return merchandiseByAvailabilityServices; });
		s.AddSingleton((s) => { return merchandiseByThemeServices; });
	})
	.Build();

host.Run();