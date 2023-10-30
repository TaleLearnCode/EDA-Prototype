﻿namespace BuildingBricks.Core.EventMessages;

public class ProductPurchasedMessage
{
	public string PurchaseId { get; set; } = null!;
	public int PurchaseItemId { get; set; }
	public string ProductId { get; set; } = null!;
	public int Quantity { get; set; }
}