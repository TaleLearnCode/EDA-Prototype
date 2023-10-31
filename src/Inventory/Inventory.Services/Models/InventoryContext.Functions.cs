namespace BuildingBricks.Inventory.Models;

public partial class InventoryContext
{

	[DbFunction("ufnGetProductInventoryOnHand", "Inventory")]
	public static int? GetProductInventoryOnHand(string ProductId)
	{
		throw new NotSupportedException("This method can only be called from Entity Framework Core queries");
	}

	[DbFunction("ufnGetReservedProductCount", "Inventory")]
	public static int? GetReservedProductCount(string ProductId)
	{
		throw new NotSupportedException("This method can only be called from Entity Framework Core queries");
	}

	protected void OnModelCreatingGeneratedFunctions(ModelBuilder modelBuilder)
	{
		modelBuilder.HasDbFunction(() => GetProductInventoryOnHand(string.Empty));
		modelBuilder.HasDbFunction(() => GetReservedProductCount(string.Empty));
	}
}