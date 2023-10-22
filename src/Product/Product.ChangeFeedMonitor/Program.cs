string environment = Environment.GetEnvironmentVariable("AZURE_FUNCTIONS_ENVIRONMENT")!;
string appConfigEndpoint = Environment.GetEnvironmentVariable("AppConfigEndpoint")!;
ConfigServices configServices = new(appConfigEndpoint, environment);

using CosmosClient cosmosClient = new(configServices.CosmosUri, configServices.CosmosKey);
Database database = cosmosClient.GetDatabase(configServices.ProductCosmosDatabaseId);

MerchandiseServices merchandiseServices = new(configServices, database.GetContainer(configServices.ProductMerchandiseContainerId));
MerchandiseByAvailabilityServices merchandiseByAvailabilityServices = new(configServices, database.GetContainer(configServices.ProductsByAvailabilityContainerId));
MerchandiseByThemeServices merchandiseByThemeServices = new(configServices, database.GetContainer(configServices.ProductsByThemeContainerId));

IHost host = new HostBuilder()
	.ConfigureFunctionsWorkerDefaults()
	.ConfigureServices(s =>
	{
		s.AddSingleton((s) => { return configServices; });
		s.AddSingleton((s) => { return merchandiseServices; });
		s.AddSingleton((s) => { return merchandiseByAvailabilityServices; });
		s.AddSingleton((s) => { return merchandiseByThemeServices; });
	})
	.Build();

host.Run();