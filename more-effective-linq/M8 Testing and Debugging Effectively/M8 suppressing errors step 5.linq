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
		.TrySelect<string,string,WebException>(DownloadAsString, LogException)
		.Where(html => Regex.Match(html, "azure").Success)
		.Dump();
}

void LogException(string url, WebException we)
{
	Console.WriteLine($"Error downloading {url}: {we.Message}");
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