<Query Kind="Statements">
  <Namespace>System.Net.Http</Namespace>
</Query>

var client = new HttpClient();
var urls = new[] { "https://www.alvinashcraft.com/",
					"http://blog.cwa.me.uk/",
					"https://azureweekly.info/"};
var regex = @"<a\s+href=(?:""([^""]+)""|'([^']+)').*?>(.*?)</a>";
var results = urls.Select(u => client.GetStringAsync(u).Result)
	.SelectMany(h => Regex.Matches(h, regex).Cast<Match>())
	.Where(m => m.Value.Contains("microsoft.com"))
	.Select(m => m.Value);
	
foreach(var result in results)
{
	Console.WriteLine(result);
}
	
