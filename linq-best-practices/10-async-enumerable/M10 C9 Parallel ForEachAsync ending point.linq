<Query Kind="Statements">
  <NuGetReference>System.Linq.Async</NuGetReference>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var client = new HttpClient();
client.DefaultRequestHeaders.Add("User-Agent", "Other");

var sites = new[] {
	"https://www.pluralsight.com",
	"https://markheath.net",
	"https://www.linqpad.net",
	"https://stackoverflow.com",
};

await Parallel.ForEachAsync(sites,
	new ParallelOptions() { MaxDegreeOfParallelism = 3 },
	async (url,cancellationToken) => await SearchSite(url, "azure")
	);

async Task SearchSite(string url, string searchTerm)
{
	var html = await client.GetStringAsync(url);
	if (Regex.Match(html, searchTerm).Success)
	{
		Console.WriteLine($"Found '{searchTerm}' in {url}");
	}
}

