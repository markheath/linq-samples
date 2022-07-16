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

// example 
var results = urls
		.ToAsyncEnumerable()
		.SelectAwait(async url => new { Url = url, Html = await httpClient.GetStringAsync(url)})
		.Where(x => x.Html.Contains("Blazor"));
await foreach(var result in results)
{
	Console.WriteLine($"Found a match in {result.Url}");
}
