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
		.TrySelect(DownloadAsString, ex => Console.WriteLine($"Error downloading: {ex.Message}"))
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