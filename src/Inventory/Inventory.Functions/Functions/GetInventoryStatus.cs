namespace Inventory.Functions;

public class GetInventoryStatus
{
	private readonly ILogger _logger;
	private readonly InventoryServices _inventoryServices;

	public GetInventoryStatus(
		ILoggerFactory loggerFactory,
		InventoryServices inventoryServices)
	{
		_logger = loggerFactory.CreateLogger<GetInventoryStatus>();
		_inventoryServices = inventoryServices;
	}

	[Function("GetInventoryStatus")]
	public async Task<HttpResponseData> RunAsync(
		[HttpTrigger(AuthorizationLevel.Function, "get", Route = "products/{productId}/inventory")] HttpRequestData request,
		string productId)
	{
		try
		{
			ArgumentNullException.ThrowIfNull(productId);
			return await request.CreateResponseAsync(await _inventoryServices.GetInventoryStatusAsync(productId));
		}
		catch (Exception ex) when (ex is ArgumentNullException)
		{
			return request.CreateBadRequestResponse(ex);
		}
		catch (Exception ex)
		{
			_logger.LogError("Unexpected exception: {ExceptionMessage}", ex.Message);
			return request.CreateErrorResponse(ex);
		}
	}

}