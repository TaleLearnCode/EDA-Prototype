using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

string appConfigEndpoint = "https://appcs-eda-prototype-use.azconfig.io";
ConfigurationBuilder builder = new();
DefaultAzureCredential defaultAzureCredential = new();
builder.AddAzureAppConfiguration(options =>
{
	options.Connect(new Uri(appConfigEndpoint), defaultAzureCredential)
	.Select(KeyFilter.Any, LabelFilter.Null)
	.Select(KeyFilter.Any, "Development")
	.ConfigureKeyVault(kv =>
	{
		kv.SetCredential(defaultAzureCredential);
	});
});
IConfigurationRoot configurationRoot = builder.Build();
Console.WriteLine(configurationRoot["Cosmos:Uri"]);
Console.WriteLine(configurationRoot["Cosmos:Key"]);