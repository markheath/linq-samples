<Query Kind="Statements">
  <NuGetReference>System.Linq.Async</NuGetReference>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
</Query>

var client = new HttpClient();
client.DefaultRequestHeaders.Add("User-Agent", "Other");

var sites = new[] {
	"https://www.pluralsight.com",
	"https://markheath.net",
	"https://www.linqpad.net",
	"https://stackoverflow.com",
};

var matches = sites
	.ToAsyncEnumerable()
	.SelectAwait(async url => new { Url = url, Html = await client.GetStringAsync(url) })
	.Where(site => Regex.Match(site.Html, "azure").Success);

await foreach (var match in matches)
{
	Console.WriteLine($"Found 'azure' in {match.Url}");
}
