<Query Kind="Program">
  <Namespace>System.Net</Namespace>
</Query>

void Main()
{
	var sites = new[] { 
		"http://www.pluralsight.com",
		"http://doesntexist.xyz",
		"http://markheath.net",
		"http://www.linqpad.net",
	};
	
	sites
		.Select(url => DownloadAsString(url))
        .Where(html => Regex.Match(html, "azure").Success)
		.Dump();
}

string DownloadAsString(string url)
{
	using (var wc = new WebClient())
	{
		return wc.DownloadString(url);
	}
}