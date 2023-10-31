namespace BuildingBricks.Inventory;

public class InventoryServices : ServicesBase
{

	public InventoryServices(ConfigServices configServices) : base(configServices) { }

	public async Task ReserveItemForOrderAsync(ProductPurchasedMessage productPurchasedMessage)
	{
		using InventoryContext inventoryContext = new(_configServices);
		Product? product = await inventoryContext.Products.FirstOrDefaultAsync(x => x.ProductId == productPurchasedMessage.ProductId);
		if (product is not null)
		{

			// Update the inventory status
			InventoryTransaction inventoryTransaction = new()
			{
				ProductId = product.ProductId,
				InventoryActionId = InventoryActions.ReservedForOrder,
				InventoryReserve = productPurchasedMessage.Quantity,
				OrderNumber = productPurchasedMessage.PurchaseId
			};
			await inventoryContext.InventoryTransactions.AddAsync(inventoryTransaction);
			await inventoryContext.SaveChangesAsync();

			// Get the inventory status
			InventoryStatusResponse? inventoryStatusResponse = await GetInventoryStatusAsync(product.ProductId, inventoryContext);

			// Send the inventory reserved message
			InventoryReservedMessage inventoryReservedMessage = new()
			{
				OrderId = productPurchasedMessage.PurchaseId,
				ProductId = productPurchasedMessage.ProductId,
				QuantityOnHand = inventoryStatusResponse?.InventoryOnHand - inventoryStatusResponse?.InventoryReserved ?? 0,
				Backordered = inventoryStatusResponse is null || inventoryStatusResponse.InventoryAvailable < 1
			};

			await SendMessageToEventHubAsync(
				_configServices.InventoryEventHubsInventoryReservedConnectionString,
				_configServices.InventoryEventHubsInventoryReservedEventHubName,
				JsonSerializer.Serialize(inventoryReservedMessage));

		}

	}

	public async Task<InventoryStatusResponse?> GetInventoryStatusAsync(string productId)
	{
		using InventoryContext inventoryContext = new(_configServices);
		return await GetInventoryStatusAsync(productId, inventoryContext);
	}

	private static async Task<InventoryStatusResponse?> GetInventoryStatusAsync(string productId, InventoryContext inventoryContext)
	{
		List<InventoryTransaction> inventoryTransactions = await inventoryContext.InventoryTransactions.Where(x => x.ProductId == productId).ToListAsync();
		if (inventoryTransactions.Any())
			return new InventoryStatusResponse()
			{
				ProductId = productId,
				InventoryOnHand = inventoryTransactions.Sum(x => x.InventoryCredit) - inventoryTransactions.Sum(x => x.InventoryDebit),
				InventoryReserved = inventoryTransactions.Sum(x => x.InventoryReserve),
				LastUpdate = inventoryTransactions.Max(x => x.ActionDateTime)
			};
		else
			return null;
	}

}