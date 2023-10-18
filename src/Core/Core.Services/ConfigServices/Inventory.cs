// Ignore Spelling: Sql

namespace BuildingBricks.Core;

public partial class ConfigServices
{

	private const string _Inventory_AzureSqlCatalog = "Inventory:AzureSql:Catalog";

	public string InventoryAzureSqlCatalog => GetConfigValue(_Inventory_AzureSqlCatalog);

}