using System.Text.RegularExpressions;
public static class ExceptionHandling
{
        // starting point
    public static void Example1()
    {
        var numbers = Enumerable.Range(1, 10)
				.Select(n => 5 - n)
				.Select(n => 10 / n);

        foreach (var n in numbers)
        {
            Console.WriteLine(n);
        }

    }

    // ineffective catch
    public static void Example2()
    {
        var numbers = Enumerable.Range(1, 10)
				.Select(n => 5 - n);
				
        try
        {
            numbers = numbers.Select(n => 10 / n);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }

        foreach (var n in numbers)
        {
            Console.WriteLine(n);
        }
    }

    // catching at enumeration time
    public static void Example3()
    {
        var numbers = Enumerable.Range(1, 10)
				.Select(n => 5 - n)
				.Select(n => 10 / n);
        try
        {
            foreach (var n in numbers)
            {
                Console.WriteLine(n);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in foreach loop: {e.Message}");
        }
    }
    
    public static void TrySelectDemo()
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

    static void LogException(string url, HttpRequestException we)
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

    static string DownloadAsString(string url)
    {
        // note: blocking call is an antipattern - see the module on IAsyncEnumerable for how to avoid this
        return client.GetStringAsync(url).GetAwaiter().GetResult();
    }

    // fully generic version
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