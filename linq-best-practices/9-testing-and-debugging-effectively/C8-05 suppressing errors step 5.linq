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
		.TrySelect<string,string,HttpRequestException>(DownloadAsString, LogException)
		.Where(html => Regex.Match(html, "azure").Success)
		.Dump();
}

void LogException(string url, HttpRequestException we)
{
	Console.WriteLine($"Error downloading {url}: {we.Message}");
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
	public static IEnumerable<TResult> TrySelect<TSource, TResult, TException>(this IEnumerable<TSource> source, 
																		Func<TSource, TResult> selector, 
																		Action<TSource, TException> exceptionAction)
																		where TException : Exception
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
			catch (TException ex)
			{
				exceptionAction(s,ex);
			}
			if (success)
			{
				// n.b. can't yield return inside a try block	
				yield return result;
			}
		}
	}
}