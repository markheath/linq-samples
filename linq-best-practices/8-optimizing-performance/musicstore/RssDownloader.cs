using System.Xml.Linq;
using HtmlAgilityPack;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public static class RssDownloader
{
    // bonus clip
    public async static Task AsyncEnumerableDemo()
    {
        	var sites = new[] {
                "https://www.alvinashcraft.com/", // Alvin Ashcraft Morning Dew
                "https://blog.cwa.me.uk/", // Chris Alcock Morning Brew
                "https://sergeytihon.com/", // Sergey Tihon F# Weekly
                "https://www.webaudioweekly.com/", // Chris Lowis Web Audio Weekly
            };
            var results = sites
                .ToAsyncEnumerable()
                .SelectAwait(async url => await DownloadHtmlAsync(url))
                .Select(ToHtmlDocument)
                .Select(GetRssFeed)
                .SelectAwait(async f => await LoadRssFeedAsync(f))
                .SelectMany(feed => GetFeedsFromXDoc(feed))
                .Where(l => l.LinkTitle.Contains("Azure") ||
                        l.LinkTitle.Contains("Blazor"))
                .GroupBy(l =>l.LinkTitle.Contains("Blazor") ? "Blazor":"Azure");
        await foreach(var result in results)
        {
            Console.WriteLine($"Results for {result.Key}");
            await foreach(var link in result)
            {
                Console.WriteLine($"{link.LinkTitle} at {link.LinkHref}");
            }
        } 
    }

    public static void PLINQDemo()
    {
        var sites = new[] {
            "https://www.alvinashcraft.com/", // Alvin Ashcraft Morning Dew
            "https://blog.cwa.me.uk/", // Chris Alcock Morning Brew
            "https://sergeytihon.com/", // Sergey Tihon F# Weekly
            "https://www.webaudioweekly.com/", // Chris Lowis Web Audio Weekly
        };
        XNamespace contentNamespace = "http://purl.org/rss/1.0/modules/content/";
        var links = from xdoc in sites.AsParallel()
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

        foreach(var result in links.Where(l => l.linkTitle.Contains("Azure") ||
                    l.linkTitle.Contains("Blazor"))
                    .GroupBy(l => l.linkTitle.Contains("Blazor") ? "Blazor":"Azure"))
        {
            Console.WriteLine($"Results for {result.Key}");
            foreach(var link in result)
            {
                Console.WriteLine($"{link.linkTitle} at {link.linkHref}");
            }
        }


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
        var resp = xmlClient.GetAsync(rssFeedLink).Result;
        if (resp.StatusCode == HttpStatusCode.TemporaryRedirect)
        {
            resp = xmlClient.GetAsync(resp.Headers.GetValues("Location").First()).Result;
        }
        var xml = resp.Content.ReadAsStringAsync().Result;
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

    private static HttpClient httpClient = new HttpClient();
    private static string DownloadHtml(string uri)
    {
        Console.WriteLine($"Downloading: {uri}");
        // note - not a recommended practice to use .Result
        // see demos later in course for a better approach
        return httpClient.GetStringAsync(uri).Result;	
    }

    private static Task<string> DownloadHtmlAsync(string uri)
    {
        Console.WriteLine($"Downloading: {uri}");
        return httpClient.GetStringAsync(uri);	
    }

    
    private async static Task<XDocument> LoadRssFeedAsync(string rssFeedLink)
    {
        // XDocument.Load doesn't follow 307 redirects (feedburner)
        var resp = await xmlClient.GetAsync(rssFeedLink);
        if (resp.StatusCode == HttpStatusCode.TemporaryRedirect)
        {
            resp = await xmlClient.GetAsync(resp.Headers.GetValues("Location").First());
        }
        var xml = await resp.Content.ReadAsStringAsync();
        return XDocument.Parse(xml);
    }

    record LinkInfo(string PostTitle, string PostLink, string LinkTitle, string LinkHref);

    private async static IAsyncEnumerable<LinkInfo> GetFeedsFromXDoc(XDocument xdoc)
    {
        XNamespace contentNamespace = "http://purl.org/rss/1.0/modules/content/";
        foreach(var feedItem in xdoc.Descendants("item"))
        {
            var postTitle = feedItem.Element("title").Value;
            var postLink = feedItem.Element("link").Value;
            // some blogs have the content embedded
            var postContent = feedItem.Element(contentNamespace + "encoded");
            var html = postContent?.Value ?? await DownloadHtmlAsync(postLink);
            var postDoc = ToHtmlDocument(html);

            foreach(var linkNode in postDoc.DocumentNode.SelectNodes("//a"))
            {
                var linkTitle = linkNode.InnerText;
                var linkHref = linkNode.Attributes["href"]?.Value;
                if(linkHref != null)
                    yield return new LinkInfo(postTitle, postLink, linkTitle, linkHref);
            }
        }
    }

}




