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

var tasks = sites
	.Select(async url => new { Url = url, Html = await client.GetStringAsync(url) });
var siteInfo = await Task.WhenAll(tasks);
	
var matches = siteInfo.Where(site => Regex.Match(site.Html, "azure").Success);

foreach (var match in matches)
{
	Console.WriteLine($"Found 'azure' in {match.Url}");
}
