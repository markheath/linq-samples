<Query Kind="Program">
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
</Query>

void Main()
{
	var sites = new[] { 
		"https://pluralsight.com",
		"https://doesntexist.xyz",
		"https://markheath.net",
		"https://www.linqpad.net",
	};
	
	sites
		.Select(url => DownloadAsString(url))
        .Where(html => Regex.Match(html, "azure").Success)
		.Dump();
}

static HttpClient client = BuildClient();

static HttpClient BuildClient()
{
	var c = new HttpClient();
	c.DefaultRequestHeaders.Add("User-Agent", "Other");
	return c;
}

string DownloadAsString(string url)
{	
	// note: blocking call is an antipattern - see the module on IAsyncEnumerable for how to avoid this
	return client.GetStringAsync(url).GetAwaiter().GetResult();
}