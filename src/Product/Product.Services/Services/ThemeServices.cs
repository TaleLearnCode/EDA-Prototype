namespace BuildingBricks.Product.Services;

public class ThemeServices : MetadataServicesBase<Theme>
{

	public ThemeServices(ConfigServices configServices, CosmosClient cosmosClient) : base(configServices, cosmosClient, Constants.MetadataType.Theme) { }

	public ThemeServices(ConfigServices configServices, Database database) : base(configServices, database, Constants.MetadataType.Theme) { }

	public ThemeServices(ConfigServices configServices, Container container) : base(configServices, container, Constants.MetadataType.Theme) { }

	public async Task<Theme> GetAsync(string id) => await GetMetadataAsync(id);

	public async Task<List<Theme>> GetListAsync() => await GetMetadataListAsync();

	public async Task<Dictionary<int, Theme>> GetDictionaryAsync() => await GetMetadataDictionaryAsync();

	public async Task<Theme> AddAsync(Theme item, bool overrideId = true) => await AddMetadataAsync(item, overrideId);

	public async Task<Theme> ReplaceAsync(Theme item) => await ReplaceMetadataAsync(item);

	public async Task<Theme> UpsertAsync(Theme item) => await UpsertMetadataAsync(item);

	public async Task<bool> DeleteAsync(Theme item) => await DeleteMetadataAsync(item);

}