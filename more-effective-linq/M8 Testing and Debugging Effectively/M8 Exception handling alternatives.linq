<Query Kind="Program">
  <Namespace>System.Net</Namespace>
</Query>

void Main()
{
	var sites = new[] { "http://www.pluralsight.com",
						"http://doesntexist.xyz",
						"http://markheath.net",
						"http://www.linqpad.net",					
						};
	// no exception handling
	
	sites
		.Select(s => DownloadAsString(s))
	  	.Select(s => s.Substring(s.IndexOf("<body",StringComparison.OrdinalIgnoreCase)+6, 100))
		;//.Dump();
	
	
	// inline
	sites
		.Select(s =>
			{
				try
				{
					return DownloadAsString(s);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					return null;
				}
			})
		.Where(s => s != null)
	  	.Select(s => s.Substring(s.IndexOf("<body", StringComparison.OrdinalIgnoreCase) + 5, 100))
		;//.Dump();

	// clean code
	sites
		.Select(TryDownloadAsString)
		.Where(s => s != null)
	  	.Select(s => s.Substring(s.IndexOf("<body", StringComparison.OrdinalIgnoreCase) + 5, 100))
		;//.Dump();
		
	sites
		.TrySelect(DownloadAsString, ex => Console.WriteLine(ex.Message))
	  	.Select(s => s.Substring(s.IndexOf("<body", StringComparison.OrdinalIgnoreCase) + 5, 100))
		.Dump();
}

string DownloadAsString(string url)
{
	using (var wc = new WebClient())
	{
		return wc.DownloadString(url);
	}
}

string TryDownloadAsString(string url)
{
	try
	{
		return DownloadAsString(url);
	}
	catch (Exception e)
	{
		Console.WriteLine(e.Message);
		return null;
	}
}

static class MyExtensions
{
	public static IEnumerable<TResult> TrySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, Action<Exception> exceptionAction)
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

	public static IEnumerable<TResult> TrySelect2<TSource, TResult, TException>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, Action<TException> exceptionAction)
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