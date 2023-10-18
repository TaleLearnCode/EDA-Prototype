// Ignore Spelling: Sql

namespace BuildingBricks.Core;

public partial class ConfigServices
{

	private const string _Purchase_AzureSqlCatalog = "Purchase:AzureSql:Catalog";

	public string PurchaseAzureSqlCatalog => GetConfigValue(_Purchase_AzureSqlCatalog);

}