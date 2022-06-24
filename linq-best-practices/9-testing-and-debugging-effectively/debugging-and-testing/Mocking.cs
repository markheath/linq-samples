using System.Net;
using System.Net.Http.Headers;
using System.Xml.Linq;
using HtmlAgilityPack;

namespace DebugAndTestDemo;

record SearchResult(string PostTitle, string PostLink, string LinkTitle, string LinkHref);


class MockingDemo
{
    public static IEnumerable<SearchResult> SearchForBlogPosts(IEnumerable<string> sites, string topic)
    {
        XNamespace contentNamespace = "http://purl.org/rss/1.0/modules/content/";
        return from xdoc in sites
            .Select(DownloadHtml)
            .Select(ToHtmlDocument)
            .Select(GetRssFeed)
            .Select(LoadRssFeed)
            from feedItem in xdoc.Descendants("item")
            let postTitle = feedItem.Element("title").Value
            let postLink = feedItem.Element("link").Value
            let postContent = feedItem.Element(contentNamespace + "encoded")
            let html = postContent?.Value ?? DownloadHtml(postLink)
            let postDoc = ToHtmlDocument(feedItem.Element(contentNamespace + "encoded")?.Value ?? "")
            from linkNode in postDoc.DocumentNode.SelectNodes("//a")
            let linkTitle = linkNode.InnerText
            let linkHref = linkNode.Attributes["href"]?.Value
            where linkHref != null
            where linkTitle.Contains(topic)
            select new SearchResult(postTitle, postLink, linkTitle, linkHref);
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
}

