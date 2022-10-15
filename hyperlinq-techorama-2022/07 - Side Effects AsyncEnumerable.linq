<Query Kind="Statements">
  <NuGetReference>System.Linq.Async</NuGetReference>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var client = new HttpClient();
var urls = new[] { "https://www.alvinashcraft.com/",
					"http://blog.cwa.me.uk/",
					"https://azureweekly.info/"};
var regex = @"<a\s+href=(?:""([^""]+)""|'([^']+)').*?>(.*?)</a>";
var results = urls.ToAsyncEnumerable() // System.LINQ.Async
	.SelectAwait(async u => await client.GetStringAsync(u))
	.SelectMany(h => Regex.Matches(h, regex).Cast<Match>().ToAsyncEnumerable())
	.Where(m => m.Value.Contains("microsoft.com"))
	.Select(m => m.Value);
	
await foreach (var result in results)
{
	Console.WriteLine(result);
}

