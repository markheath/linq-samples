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
		.Select(url =>
		{
			try
			{
				return DownloadAsString(url);
            }
			catch (Exception e)
			{
				Console.WriteLine($"Error downloading {url}: {e.Message}");
				return null;
			}
		})
		.Where(html => html != null)
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