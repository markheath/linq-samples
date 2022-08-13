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
		.TrySelect(DownloadAsString, ex => Console.WriteLine($"Error downloading: {ex.Message}"))
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

static class MyExtensions
{
	public static IEnumerable<TResult> TrySelect<TSource, TResult>(this IEnumerable<TSource> source, 
																		Func<TSource, TResult> selector, 
																		Action<Exception> exceptionAction)
	{
		foreach (var s in source)
		{
			TResult result = default(TResult);
			bool success = false;
			try
			{
				result = selector(s);
				success = true;
			}
			catch (Exception ex)
			{
				exceptionAction(ex);
			}
			if (success)
			{
				// n.b. can't yield return inside a try block	
				yield return result;
			}
		}
	}
}