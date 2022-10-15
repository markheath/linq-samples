<Query Kind="Statements">
  <NuGetReference>System.Linq.Async</NuGetReference>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var client = new HttpClient();
var urls = new[] { "https://www.alvinashcraft.com/",
					"http://blog.cwa.me.uk/",
					"https://azureweekly.info/"};

IAsyncEnumerable<string> Find(IEnumerable<string> urls, string searchTerm,
	Func<string, ValueTask<string>> downloadHtml)
{
	var regex = @"<a\s+href=(?:""([^""]+)""|'([^']+)').*?>(.*?)</a>";

	return urls.ToAsyncEnumerable() // System.LINQ.Async
		.SelectAwait(downloadHtml)
		.SelectMany(h => Regex.Matches(h, regex).Cast<Match>().ToAsyncEnumerable())
		.Where(m => m.Value.Contains(searchTerm))
		.Select(m => m.Value);

}

var results = Find(urls, "microsoft.com", async url => await client.GetStringAsync(url));

await foreach (var result in results)
{
	Console.WriteLine(result);
}

