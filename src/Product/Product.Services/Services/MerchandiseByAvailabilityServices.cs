﻿namespace BuildingBricks.Product.Services;

public class MerchandiseByAvailability : ServicesBase<Merchandise>
{

	public MerchandiseByAvailability(ConfigServices configServices, CosmosClient cosmosClient) : base(configServices, cosmosClient, configServices.ProductsByAvailabilityContainerId) { }

	public MerchandiseByAvailability(ConfigServices configServices, Database database) : base(database, configServices.ProductsByAvailabilityContainerId) { }

	public MerchandiseByAvailability(ConfigServices configServices, Container container) : base(container) { }

	public async Task<List<Merchandise>> GetAsync(string availabilityId) => await GetListAsync($"SELECT * FROM merchandise WHERE availabilityId = '{availabilityId}'");

	public async Task<Dictionary<string, Merchandise>> GetDictionaryAsync() => (await GetListAsync("SELECT * FROM merchandise")).ToDictionary(x => x.AvailabilityId, x => x);

}