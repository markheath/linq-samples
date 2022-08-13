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
		.Select(url => DownloadHtml(url))
		.Where(html => html.Contains("Blazor"));
		
foreach(var result in results)
{
	Console.WriteLine($"Found a match");
}

string DownloadHtml(string url)
{
	// note: blocking with .Result is an anti-pattern!
	return httpClient.GetStringAsync(url).Result;
}



