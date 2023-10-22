namespace BuildingBricks.EventMessages;

public class InventoryReservedMessage
{
	public string OrderId { get; set; } = null!;
	public string ProductId { get; set; } = null!;
}