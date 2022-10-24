using System.Net;
using System.Net.Http.Headers;
using System.Xml.Linq;
using HtmlAgilityPack;
using MusicStore;

public static class Module7Demos
{
    // clip 2
    public static void DeferredExecutionDemo()
    {
        var strings = new List<string>() { "Ben", "Lily", "Joel", "Sam", "Annie" };
        strings.Select(s => s.ToUpper());
        var uppercase = strings
            .Select(s => { Console.WriteLine(s); return s.ToUpper(); })
            .Where(s => s.Length > 3)
            .ToList();
        foreach (var upper in uppercase)
        {
            Console.WriteLine(upper);
        }
    }

    // clip 3 and 5 
    public static void RSSDownloader()
    {
        var sites = new[] {
            "https://www.alvinashcraft.com/", // Alvin Ashcraft Morning Dew
            "https://blog.cwa.me.uk/", // Chris Alcock Morning Brew
            "https://sergeytihon.com/", // Sergey Tihon F# Weekly
            "https://www.webaudioweekly.com/", // Chris Lowis Web Audio Weekly
        };
	    XNamespace contentNamespace = "http://purl.org/rss/1.0/modules/content/";
        var links = from xdoc in sites
                    .Select(DownloadHtml)
                    .Select(ToHtmlDocument)
                    .Select(GetRssFeed)
                    .Select(LoadRssFeed)

        from feedItem in xdoc.Descendants("item")	
            let postTitle = feedItem.Element("title").Value
            let postLink = feedItem.Element("link").Value
            // some blogs have the content embedded
            let postContent = feedItem.Element(contentNamespace + "encoded")
            let html = postContent?.Value ?? DownloadHtml(postLink)
            let postDoc = ToHtmlDocument(html)
        from linkNode in postDoc.DocumentNode.SelectNodes("//a")
            let linkTitle = linkNode.InnerText
            let linkHref = linkNode.Attributes["href"]?.Value
        where linkHref != null
        select new { postTitle, postLink, linkTitle, linkHref };


        //links.Where(l => l.linkTitle.Contains("Azure")).Dump("Example 1");
        //links.First(l => l.linkTitle.Contains("Azure")).Dump("Example 2");

        /*var list = links.ToList();
        Console.WriteLine($"Found {list.Count} links");
        list.First(l => l.linkTitle.Contains("Azure"))
            .Dump("Example 3");*/

	
        //links.Where(l => l.linkTitle.Contains("Azure")).Dump("Example 4a");
        //links.Where(l => l.linkTitle.Contains("Blazor")).Dump("Example 4b");

        /*links.Where(l => l.linkTitle.Contains("Azure") ||
                    l.linkTitle.Contains("Blazor"))
                    .GroupBy(l => l.linkTitle.Contains("Blazor") ? "Blazor":"Azure")
                    .Dump("Example 5");*/

    	/*
        var list = links.ToList();	
        list.Where(l => l.linkTitle.Contains("Azure")).Dump("Example 6a");
        list.Where(l => l.linkTitle.Contains("Blazor")).Dump("Example 6b");
    	*/
    }

    static HttpClient xmlClient = BuildXmlClient();

    private static HttpClient BuildXmlClient()
    {
        var c = new HttpClient();
        c.DefaultRequestHeaders.Accept.
            Add(new MediaTypeWithQualityHeaderValue("application/xml"));
        return c;
    }

    private static XDocument LoadRssFeed(string rssFeedLink)
    {
        // XDocument.Load doesn't follow 307 redirects (feedburner)
        var resp = xmlClient.Send(new HttpRequestMessage(HttpMethod.Get, rssFeedLink));
        if (resp.StatusCode == HttpStatusCode.TemporaryRedirect)
        {
            var redirectLocation = resp.Headers.GetValues("Location").First();
            resp = xmlClient.Send(new HttpRequestMessage(HttpMethod.Get, redirectLocation));
        }
        using var stringReader = new StreamReader(resp.Content.ReadAsStream());
        var xml = stringReader.ReadToEnd(); 
        return XDocument.Parse(xml);
    }

    private static string GetRssFeed(HtmlDocument htmlDoc)
    {
        return htmlDoc.DocumentNode
            .SelectNodes("//link[(@type='application/rss+xml' or @type='application/atom+xml') and @rel='alternate']")
            .Select(n => n.Attributes["href"].Value)
            .First();
    }

    private static HtmlDocument ToHtmlDocument(string html)
    {
        var htmlDoc = new HtmlDocument();	
        htmlDoc.LoadHtml(html);
        return htmlDoc;
    }

    private static string DownloadHtml(string uri)
    {
        Console.WriteLine($"Downloading: {uri}");
        return DownloadAsString(uri);
    }

    private static HttpClient httpClient = new HttpClient();
    private static string DownloadAsString(string uri)
    {
        // note: we're only using Send here to avoid having to block on async methods
        // later in the course we'll see how to use async methods in a LINQ pipeline
        var resp = httpClient.Send(new HttpRequestMessage(HttpMethod.Get, uri));
        using var streamReader = new StreamReader(resp.Content.ReadAsStream());
        return streamReader.ReadToEnd();
    }

    // clip 4
    class Order
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }
    }

    public static void BreakOutEarlyDemo()
    {
        List<Order> orders = new List<Order>()
        {
            new Order { Id = 123, Amount = 29.95m, CustomerName = "Mark", Status = "Delivered" },
            new Order { Id = 456, Amount = 45.00m, CustomerName = "Steph", Status = "Refunded" },
            new Order { Id = 768, Amount = 32.50m, CustomerName = "Claire", Status = "Delivered" },
        };
        CheckOrdersForRefundsLinq();


        void CheckOrdersForRefunds()
        {
            bool anyRefunded = orders.Any(o => o.Status == "Refunded");
                
            if (anyRefunded)
                Console.WriteLine("There are refunded orders");
            else
                Console.WriteLine("No refunds");
        }

        void CheckOrdersForRefundsLinq()
        {
            bool anyRefunded = orders.Any(o => o.Status == "Refunded");

            if (anyRefunded)
                Console.WriteLine("There are refunded orders");
            else
                Console.WriteLine("No refunds");
        }

        void CheckOrdersAreDeliveredLinq()
        {
            bool allDelivered = orders.All(o => o.Status == "Delivered");

            if (allDelivered)
                Console.WriteLine("Everything was delivered");
            else
                Console.WriteLine("Not everything was delivered");
        }
    }

    // clip 6 - Multiple Enumeration Database
    public static void MultipleEnumerationDatabase()
    {
        using var db = new MusicStoreDb();
        db.Albums.Where(a => a.Title.Contains("Greatest Hits")).Dump();
        db.Albums.Where(a => a.Title.Contains("Live")).Dump();

        var albumsInMemory = db.Albums.ToList();
        albumsInMemory.Where(a => a.Title.Contains("Greatest Hits")).Dump();
        albumsInMemory.Where(a => a.Title.Contains("Live")).Dump();
    }
    // clip 7
    public static void MultipleEnumerationCorrectness()
    {
        var numbers = GetNumbers(); // fix issue with .ToList();
        numbers.Sum().Dump("Sum");
        numbers.Sum().Dump("Sum");
        numbers.Sum().Dump("Sum");
        numbers.Sum().Dump("Sum");

        IEnumerable<int> GetNumbers()
        {
            var rand = Random.Shared;
            var count = rand.Next(5, 10);
            return Enumerable.Range(0, count).Select(n => rand.Next(0, 10));
        }

    }

}