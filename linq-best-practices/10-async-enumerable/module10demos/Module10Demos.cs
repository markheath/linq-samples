using System.Net;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

public static class Module10Demos
{
    // clip 1
    public static void TheProblemExample1()
    {
        var httpClient = new HttpClient();
        var urls = new[] {
                "https://www.alvinashcraft.com/", // Alvin Ashcraft Morning Dew
                "https://blog.cwa.me.uk/", // Chris Alcock Morning Brew
                "https://sergeytihon.com/", // Sergey Tihon F# Weekly
                "https://www.webaudioweekly.com/", // Chris Lowis Web Audio Weekly
            };
            
        var results = urls
                .Select(url => DownloadHtml(url))
                .Where(html => html.Contains("Blazor"));
                
        foreach(var result in results)
        {
            Console.WriteLine($"Found a match");
        }

        string DownloadHtml(string url)
        {
            // note: blocking with .Result is an anti-pattern!
            return httpClient.GetStringAsync(url).Result;
        }
    }

    public static void TheProblemExample2()
    {       
        var httpClient = new HttpClient();
        var urls = new[] {
                "https://www.alvinashcraft.com/", // Alvin Ashcraft Morning Dew
                "https://blog.cwa.me.uk/", // Chris Alcock Morning Brew
                "https://sergeytihon.com/", // Sergey Tihon F# Weekly
                "https://www.webaudioweekly.com/", // Chris Lowis Web Audio Weekly
            };
            
        var results = urls
                .Select(async url => await DownloadHtmlAsync(url))
                .Where(html => html.Result.Contains("Blazor"));
                
        foreach(var result in results)
        {
            Console.WriteLine($"Found a match");
        }

        async Task<string> DownloadHtmlAsync(string url)
        {
            return await httpClient.GetStringAsync(url);
        }
    }

    // clip 3 - generating IAsyncEnumerable
    public static void GeneratingIAsyncEnumerable()
    {
        GetMessages(10).Dump(); // n.b. the dump method in this project probably won't do well with IAsyncEnumerable - see next demo

        async IAsyncEnumerable<string> GetMessages(int count)
        {
            for (var n = 0; n < count; n++)
            {
                var message = await GetMessageAsync(n);
                yield return message;
            }
        }

        async Task<string> GetMessageAsync(int n)
        {
            await Task.Delay(500); // simulate a network call
            return $"Hello world {n + 1}";
        }
    }

    // clip 4 consuming IAsyncEnumerable
    public static async Task ConsumingIAsyncEnumerable()
    {
        await foreach (var message in GetMessages(10))
        {
            Console.WriteLine(message);
        }

        async IAsyncEnumerable<string> GetMessages(int count)
        {
            for (var n = 0; n < count; n++)
            {
                var message = await GetMessageAsync(n);
                yield return message;
            }
        }

        async Task<string> GetMessageAsync(int n)
        {
            await Task.Delay(500); // simulate a network call
            return $"Hello world {n + 1}";
        }
    }

    // clip 5 - cancelling IAsyncEnumerable
    public static async Task CancellingIAsyncEnumerable()
    {
        var cts = new CancellationTokenSource();
        cts.CancelAfter(TimeSpan.FromSeconds(3));
        await foreach (var message in GetMessages(10).WithCancellation(cts.Token))
        {
            // cts.Token.ThrowIfCancellationRequested();
            Console.WriteLine(message);
        }

        async IAsyncEnumerable<string> GetMessages(int count, [EnumeratorCancellation] CancellationToken ct = default)
        {
            for (var n = 0; n < count; n++)
            {
                var message = await GetMessageAsync(n, ct);
                yield return message;
            }
        }

        async Task<string> GetMessageAsync(int n, CancellationToken ct = default)
        {
            await Task.Delay(500, ct); // simulate a network call
            return $"Hello world {n + 1}";
        }
    }

    // clip 6 IAsyncEnumerable pipelines
    public async static Task PipelinesWithSystemLinqAsyncNuget()
    {
        var messages = GetMessages(10)
				.Where(m => m.EndsWith("3"))
				.Select(m => m.ToUpper());
        await foreach (var message in messages)
        {
            Console.WriteLine(message);
        }

        async IAsyncEnumerable<string> GetMessages(int count)
        {
            for (var n = 0; n < count; n++)
            {
                var message = await GetMessageAsync(n);
                yield return message;
            }
        }

        async Task<string> GetMessageAsync(int n)
        {
            await Task.Delay(500); // simulate a network call
            return $"Hello world {n + 1}";
        }
    }

    // clip 6
    public static async Task PipelinesToListAsync()
    {
        var messages = await GetMessages(10)
                        .Where(m => m.EndsWith("3"))
                        .Select(m => m.ToUpper())
                        .ToListAsync();
        foreach (var message in messages)
        {
            Console.WriteLine(message);
        }

        async IAsyncEnumerable<string> GetMessages(int count)
        {
            for (var n = 0; n < count; n++)
            {
                var message = await GetMessageAsync(n);
                yield return message;
            }
        }

        async Task<string> GetMessageAsync(int n)
        {
            await Task.Delay(500); // simulate a network call
            return $"Hello world {n + 1}";
        }
    }

    // clip 7 async lambdas selectawait
    public static async Task AsyncLambdasSelectAwait()
    {
        var messages = GetMessages(10)
                        .WhereAwait(async m => await CalculateSentiment(m) > 5)
                        .SelectAwait(async m => await TranslateMessage(m));

        await foreach (var message in messages)
        {
            Console.WriteLine(message);
        }

        async Task<string> TranslateMessage(string message)
        {
            await Task.Delay(500); // simulate a network call
            return message.Replace("Hello", "Bonjour")
                    .Replace("world", "le monde");
        }

        async Task<int> CalculateSentiment(string message)
        {
            await Task.Delay(500); // simulate a network call
            return Random.Shared.Next(0,10);
        }

        async IAsyncEnumerable<string> GetMessages(int count)
        {
            for (var n = 0; n < count; n++)
            {
                var message = await GetMessageAsync(n);
                yield return message;
            }
        }

        async Task<string> GetMessageAsync(int n)
        {
            await Task.Delay(500); // simulate a network call
            return $"Hello world {n + 1}";
        }
    }

    public static async Task AsyncLambdasToAsyncEnumerable()
    {
        var messages = new[] { "Hello world 10", "Hello world 20", "Hello world 30", "Hello world 40" }
                        .ToAsyncEnumerable()
                        .WhereAwait(async m => await CalculateSentiment(m) > 5)
                        .SelectAwait(async m => await TranslateMessage(m));

        await foreach (var message in messages)
        {
            Console.WriteLine(message);
        }

        async Task<string> TranslateMessage(string message)
        {
            await Task.Delay(500); // simulate a network call
            return message.Replace("Hello", "Bonjour")
                    .Replace("world", "le monde");
        }

        async Task<int> CalculateSentiment(string message)
        {
            await Task.Delay(500); // simulate a network call
            return Random.Shared.Next(0,10);
        }
    }

    // clip 8
    public static void IAsyncEnumerableInActionStartingPoint()
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "Other");

        var sites = new[] {
            "https://www.pluralsight.com",
            "https://markheath.net",
            "https://www.linqpad.net",
            "https://stackoverflow.com",
        };

        var matches = sites
            .Select(url => new { Url = url, Html = client.GetStringAsync(url).Result })
            .Where(site => Regex.Match(site.Html, "azure").Success);

        foreach (var match in matches)
        {
            Console.WriteLine($"Found 'azure' in {match.Url}");
        }
    }    

    public async static Task IAsyncEnumerableInActionEndingPoint()
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "Other");

        var sites = new[] {
            "https://www.pluralsight.com",
            "https://markheath.net",
            "https://www.linqpad.net",
            "https://stackoverflow.com",
        };

        var matches = sites
            .ToAsyncEnumerable()
            .SelectAwait(async url => new { Url = url, Html = await client.GetStringAsync(url) })
            .Where(site => Regex.Match(site.Html, "azure").Success);

        await foreach (var match in matches)
        {
            Console.WriteLine($"Found 'azure' in {match.Url}");
        }
    }

    // clip 9 Parallel.ForEachAsync
    public async static Task ParallelForEachAsync()
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "Other");

        var sites = new[] {
            "https://www.pluralsight.com",
            "https://markheath.net",
            "https://www.linqpad.net",
            "https://stackoverflow.com",
        };

        var options = new ParallelOptions() { MaxDegreeOfParallelism = 3 };

        await Parallel.ForEachAsync(sites, options,
            async (url,cancellationToken) => await SearchSite(url, "azure"));

        async Task SearchSite(string url, string searchTerm)
        {
            var html = await client.GetStringAsync(url);
            if (Regex.Match(html, searchTerm).Success)
            {
                Console.WriteLine($"Found '{searchTerm}' in {url}");
            }
        }
    }

}