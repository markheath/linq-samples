<Query Kind="Statements">
  <NuGetReference>System.Linq.Async</NuGetReference>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var httpClient = new HttpClient();
var urls = new[] {
		"https://www.alvinashcraft.com/", // Alvin Ashcraft Morning Dew
		"https://blog.cwa.me.uk/", // Chris Alcock Morning Brew
		"https://sergeytihon.com/", // Sergey Tihon F# Weekly
		"https://www.webaudioweekly.com/", // Chris Lowis Web Audio Weekly
	};
var sw = Stopwatch.StartNew();
var results = urls.ToAsyncEnumerable()
		.SelectAwait(async url => new { Url = url, Html = await httpClient.GetStringAsync(url)})
		.Where(x => x.Html.Contains("Blazor"));
await foreach(var result in results)
{
	Console.WriteLine($"Found a match in {result.Url}");
}
Console.WriteLine($"Series {sw.Elapsed}");

sw.Restart();
var tasks = urls
		.Select(async url => new { Url = url, Html = await httpClient.GetStringAsync(url) });
var results2 = await Task.WhenAll(tasks);
foreach(var result in results2.Where(x => x.Html.Contains("Blazor")))
{
	Console.WriteLine($"Found a match in {result.Url}");
}
Console.WriteLine($"Parallel {sw.Elapsed}");

async Task FindMatch(string url, string searchTerm) {
	var html = await httpClient.GetStringAsync(url);
	if (html.Contains(searchTerm))
	{
		Console.WriteLine($"Found a match in {url}");
	}
}

//var parallelOptions = new ParallelOptions() { MaxDegreeOfParallelism = 4};
sw.Restart();
await Parallel.ForEachAsync(urls, async (url, ct) => await FindMatch(url, "Blazor"));
Console.WriteLine($"Parallel 2 {sw.Elapsed}");


var parallelOptions = new ParallelOptions() { MaxDegreeOfParallelism = 2};
sw.Restart();
await Parallel.ForEachAsync(urls, parallelOptions, async (url, ct) => await FindMatch(url, "Blazor"));
Console.WriteLine($"Parallel 3 {sw.Elapsed}");

/*
Found a match in https://www.alvinashcraft.com/
Found a match in https://sergeytihon.com/
Series 00:00:03.5412693
Found a match in https://www.alvinashcraft.com/
Found a match in https://sergeytihon.com/
Parallel 00:00:00.9066897
Found a match in https://www.alvinashcraft.com/
Found a match in https://sergeytihon.com/
Parallel 2 00:00:00.8041609
Found a match in https://www.alvinashcraft.com/
Found a match in https://sergeytihon.com/
Parallel 3 00:00:01.4155400
*/
