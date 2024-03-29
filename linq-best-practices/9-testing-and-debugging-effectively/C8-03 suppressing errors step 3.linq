<Query Kind="Program">
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
</Query>

void Main()
{
	var sites = new[] {
		"https://www.pluralsight.com",
		"https://doesntexist.xyz",
		"https://markheath.net",
		"https://www.linqpad.net",
	};

	sites
		.Select(url => TryDownloadAsString(url))
		.Where(result => result.Error == null)
		.Select(result => result.Html)
		.Where(html => Regex.Match(html, "azure").Success)
		.Dump();
}

record DownloadResult(string Html, Exception Error);

DownloadResult TryDownloadAsString(string url)
{
	try
	{
		return new DownloadResult(DownloadAsString(url), null);
	}
	catch (HttpRequestException we)
	{
		return new DownloadResult(null, we);
	}
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