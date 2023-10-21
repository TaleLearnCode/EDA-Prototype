namespace BuildingBricks.Product.Services;

public class AvailabilityServices : MetadataServicesBase<Availability>
{

	public AvailabilityServices(ConfigServices configServices, CosmosClient cosmosClient) : base(configServices, cosmosClient, Constants.MetadataType.Availability) { }

	public AvailabilityServices(ConfigServices configServices, Database database) : base(configServices, database, Constants.MetadataType.Availability) { }

	public AvailabilityServices(ConfigServices configServices, Container container) : base(configServices, container, Constants.MetadataType.Availability) { }

	public async Task<Availability> GetAsync(string id) => await GetMetadataAsync(id);

	public async Task<List<Availability>> GetListAsync() => await GetMetadataListAsync();

	public async Task<Dictionary<int, Availability>> GetDictionaryAsync() => await GetMetadataDictionaryAsync();

	public async Task<Availability> AddAsync(Availability item, bool overrideId = true) => await AddMetadataAsync(item, overrideId);

	public async Task<Availability> ReplaceAsync(Availability item) => await ReplaceMetadataAsync(item);

	public async Task<Availability> UpsertAsync(Availability item) => await UpsertMetadataAsync(item);

	public async Task<bool> DeleteAsync(Availability item) => await DeleteMetadataAsync(item);

}