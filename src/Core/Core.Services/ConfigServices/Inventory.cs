// Ignore Spelling: Sql

namespace BuildingBricks.Core;

public partial class ConfigServices
{

	private const string _Inventory_AzureSqlCatalog = "Inventory:AzureSql:Catalog";
	private const string _Inventory_EventHubs_InventoryReserved_ConnectionString = "Inventory:EventHubs:InventoryReserved:ConnectionString";
	private const string _Inventory_EventHubs_InventoryReserved_EventHubName = "Inventory:EventHubs:InventoryReserved:EventHubName";

	public string InventoryAzureSqlCatalog => GetConfigValue(_Inventory_AzureSqlCatalog);

	public string InventoryEventHubsInventoryReservedConnectionString => GetConfigValue(_Inventory_EventHubs_InventoryReserved_ConnectionString);

	public string InventoryEventHubsInventoryReservedEventHubName => GetConfigValue(_Inventory_EventHubs_InventoryReserved_EventHubName);

}