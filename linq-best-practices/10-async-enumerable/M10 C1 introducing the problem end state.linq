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
	
var results = urls
		.Select(async url => await DownloadHtmlAsync(url))
		.Where(html => html.Result.Contains("Blazor"));
		
foreach(var result in results)
{
	Console.WriteLine($"Found a match");
}

async Task<string> DownloadHtmlAsync(string url)
{
	return await httpClient.GetStringAsync(url);
}




