using BuildingBricks.Core.EventMessages;
using BuildingBricks.Inventory.Constants;
using BuildingBricks.Inventory.Models;

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

			InventoryTransaction inventoryTransaction = new()
			{
				ProductId = product.ProductId,
				InventoryActionId = InventoryActions.ReservedForOrder,
				InventoryReserve = productPurchasedMessage.Quantity,
				OrderNumber = productPurchasedMessage.PurchaseId
			};
			await inventoryContext.InventoryTransactions.AddAsync(inventoryTransaction);
			await inventoryContext.SaveChangesAsync();



		}
	}

}