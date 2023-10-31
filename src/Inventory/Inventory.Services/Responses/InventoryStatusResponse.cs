namespace BuildingBricks.Inventory.Responses;

public class InventoryStatusResponse
{
	public string ProductId { get; set; } = null!;
	public int InventoryOnHand { get; set; }
	public int InventoryReserved { get; set; }
	public int InventoryAvailable => InventoryOnHand - InventoryReserved;
	public DateTime LastUpdate { get; set; }
}