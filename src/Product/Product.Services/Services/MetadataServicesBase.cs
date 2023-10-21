﻿namespace BuildingBricks.Product.Services;

public abstract class MetadataServicesBase<T> : ServicesBase<T> where T : Metadata
{

	private readonly string _partitionKeyValue;
	private readonly string _queryText;

	protected MetadataServicesBase(
		ConfigServices configServices,
		CosmosClient cosmosClient,
		string metadataType) : base(configServices, cosmosClient, configServices.ProductMerchandiseContainerId)
	{
		_partitionKeyValue = configServices.ProductMetadataPartitionKey;
		_queryText = $"SELECT * FROM metadata WHERE metadataType = '{metadataType}'";
	}

	protected MetadataServicesBase(
		ConfigServices configServices,
		Database database,
		string metadataType) : base(database, configServices.ProductMerchandiseContainerId)
	{
		_partitionKeyValue = configServices.ProductMetadataPartitionKey;
		_queryText = $"SELECT * FROM metadata WHERE metadataType = '{metadataType}'";
	}

	protected MetadataServicesBase(
		ConfigServices configServices,
		Container container,
		string metadataType) : base(container)
	{
		_partitionKeyValue = configServices.ProductMetadataPartitionKey;
		_queryText = $"SELECT * FROM metadata WHERE metadataType = '{metadataType}'";
	}

	public async Task<T> GetMetadataAsync(string id) => await GetAsync(id, _partitionKeyValue);

	public async Task<List<T>> GetMetadataListAsync() => await GetListAsync(_queryText);

	public async Task<Dictionary<int, T>> GetMetadataDictionaryAsync() => (await GetListAsync(_queryText)).ToDictionary(x => x.LegacyId, x => x);

	public async Task<T> AddMetadataAsync(T item, bool overrideId = true) => await AddAsync(item, _partitionKeyValue, overrideId);

	public async Task<T> ReplaceMetadataAsync(T item) => await ReplaceAsync(item, _partitionKeyValue);

	public async Task<T> UpsertMetadataAsync(T item) => await UpsertAsync(item, _partitionKeyValue);

	public async Task<bool> DeleteMetadataAsync(T item) => await DeleteAsync(item, _partitionKeyValue);

}