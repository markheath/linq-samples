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
		.Select(url => TryDownloadAsString(url))
		.Where(result => result.Error == null)
		.Select(result => result.Html)
		.Where(html => Regex.Match(html, "azure").Success)
		.Dump();
}

class DownloadResult
{
	public string Html { get; set; }
	public Exception Error { get; set; }
}

DownloadResult TryDownloadAsString(string url)
{
	try
	{
		return new DownloadResult { Html = DownloadAsString(url) };
	}
	catch (WebException we)
	{
		return new DownloadResult { Error = we };
	}
}

string DownloadAsString(string url)
{
	using (var wc = new WebClient())
	{
		return wc.DownloadString(url);
	}
}