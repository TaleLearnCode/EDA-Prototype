using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.ServiceBus;
using System.Text;

namespace BuildingBricks.Core;

public abstract class ServicesBase
{

	protected readonly ConfigServices _configServices;

	protected ServicesBase(ConfigServices configServices) => _configServices = configServices;

	protected static async Task SendMessageToEventHubAsync(
		string connectionString,
		string eventHubName,
		string message)
	{

		await using EventHubProducerClient producerClient = new(connectionString, eventHubName);

		using EventDataBatch eventDataBatch = await producerClient.CreateBatchAsync();
		if (!eventDataBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes(message))))
			throw new Exception("Could not add event to batch");

		try
		{
			await producerClient.SendAsync(eventDataBatch);
		}
		finally
		{
			await producerClient.CloseAsync();
		}

	}

	protected static ServiceBusClient GetServiceBusClient(string connectionString) => new(connectionString);

	protected static async Task SendSessionMessageToServiceBusAsync(
		string connectionString,
		string queueName,
		string sessionId,
		string message)
	{

		await using ServiceBusClient client = GetServiceBusClient(connectionString);
		ServiceBusSender sender = client.CreateSender(queueName);

		ServiceBusMessage serviceBusMessage = new(Encoding.UTF8.GetBytes(message))
		{
			SessionId = sessionId
		};

		await sender.SendMessageAsync(serviceBusMessage);

	}

}