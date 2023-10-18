// Ignore Spelling: Sql

namespace BuildingBricks.Core;

public partial class ConfigServices
{

	private const string _Notice_AzureSqlCatalog = "Notice:AzureSql:Catalog";

	public string NoticeAzureSqlCatalog => GetConfigValue(_Notice_AzureSqlCatalog);

}