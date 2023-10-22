using BuildingBricks.Purchase.Models;
using BuildingBricks.Purchase.Requests;

namespace BuildingBricks.Purchase;

public class PurchaseServices : ServicesBase
{

	public PurchaseServices(ConfigServices configServices) : base(configServices) { }

	public async Task<string> PlaceOrderAsync(PlaceOrderRequest placeOrderRequest)
	{
		string purchaseId = Guid.NewGuid().ToString();
		using PurchaseContext purchaseContext = new(_configServices);
		CustomerPurchase customerPurchase = new()
		{
			CustomerPurchaseId = purchaseId,
			CustomerId = placeOrderRequest.CustomerId,
			PurchaseLineItems = BuildPurchaseItemsList(placeOrderRequest, purchaseId)
		};
		await purchaseContext.CustomerPurchases.AddAsync(customerPurchase);
		await purchaseContext.SaveChangesAsync();


		List<PurchaseLineItem> purchaseLineItems = BuildPurchaseItemsList(placeOrderRequest, purchaseId);
		purchaseContext.PurchaseLineItems.AddRange(purchaseLineItems);
		await purchaseContext.SaveChangesAsync();
		return purchaseId;
	}

	private static List<PurchaseLineItem> BuildPurchaseItemsList(PlaceOrderRequest placeOrderRequest, string purchaseId)
	{
		List<PurchaseLineItem> purchaseLineItems = new();
		foreach (PlaceOrderItem item in placeOrderRequest.Items)
		{
			purchaseLineItems.Add(new PurchaseLineItem
			{
				CustomerPurchaseId = purchaseId,
				ProductId = item.ProductId,
				Quantity = item.Quantity
			});
		}
		return purchaseLineItems;
	}

	public async Task<CustomerPurchase?> GetPurchase(string purchaseId)
	{
		using PurchaseContext context = new(_configServices);
		return await context.CustomerPurchases.FirstOrDefaultAsync(x => x.CustomerPurchaseId == purchaseId);
	}

}