// Ignore Spelling: Metadata

namespace BuildingBricks.Core;

public partial class ConfigServices
{

	private const string _Product_CosmosDatabaseId = "Product:Cosmos:DatabaseId";
	private const string _Product_MetadataContainerId = "Product:Cosmos:Metadata:ContainerId";
	private const string _Product_MetadataPartitionKey = "Product:Cosmos:Metadata:PartitionKey";
	private const string _Product_ProductsByAvailabilityContainerId = "Product:Cosmos:ProductsByAvailability:ContainerId";
	private const string _Product_ProductsByAvailabilityPartitionKey = "Product:Cosmos:ProductsByAvailability:PartitionKey";
	private const string _Product_ProductsByThemeContainerId = "Product:Cosmos:ProductsByTheme:ContainerId";
	private const string _Product_ProductsByThemePartitionKey = "Product:Cosmos:ProductsByTheme:PartitionKey";

	public string ProductCosmosDatabaseId => GetConfigValue(_Product_CosmosDatabaseId);

	public string ProductMetadataContainerId => GetConfigValue(_Product_MetadataContainerId);

	public string ProductMetadataPartitionKey => GetConfigValue(_Product_MetadataPartitionKey);

	public string ProductsByAvailabilityContainerId => GetConfigValue(_Product_ProductsByAvailabilityContainerId);

	public string ProductsByAvailabilityPartitionKey => GetConfigValue(_Product_ProductsByAvailabilityPartitionKey);

	public string ProductsByThemeContainerId => GetConfigValue(_Product_ProductsByThemeContainerId);

	public string ProductsByThemePartitionKey => GetConfigValue(_Product_ProductsByThemePartitionKey);

}