namespace BuildingBricks.EventMessages;

public class InventoryReservedMessage
{
	public string OrderId { get; set; } = null!;
	public string ProductId { get; set; } = null!;
	public int QuantityOnHand { get; set; }
	public bool Backordered { get; set; }
}