<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Namespace>System.Net.Http</Namespace>
</Query>

var client = new HttpClient();
var uris = new [] { "https://www.alvinashcraft.com/",
					"http://blog.cwa.me.uk/",
					"https://codeopinion.com/"};
var regex = @"<a\s+href=(?:""([^""]+)""|'([^']+)').*?>(.*?)</a>";
uris.Select(u => client.GetStringAsync(u).Result)
	.SelectMany(h => Regex.Matches(h, regex).Cast<Match>())
	.Where(m => m.Value.Contains("markheath"))
	.Select(m => m.Value)
	.Dump();