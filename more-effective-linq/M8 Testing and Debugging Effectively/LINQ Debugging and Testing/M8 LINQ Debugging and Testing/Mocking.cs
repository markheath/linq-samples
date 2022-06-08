using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HtmlAgilityPack;

namespace M8_LINQ_Debugging_and_Testing
{
    class SearchResult
    {
        public string Title { get; set; }
        public string PostTitle { get; set; }
        public string PostLink { get; set; }
        public string LinkTitle { get; set; }
        public string LinkHref { get; set; }
    }


    class MockingDemo
    {
        public static IEnumerable<SearchResult> SearchForBlogPosts(IEnumerable<string> sites, string topic)
        {
            XNamespace contentNamespace = "http://purl.org/rss/1.0/modules/content/";
            return from xdoc in sites
                .Select(DownloadHtml)
                .Select(ToHtmlDocument)
                .Select(GetRssFeed)
                .Select(XDocument.Load)
                from feedItem in xdoc.Descendants("item")
                let postTitle = feedItem.Element("title")?.Value ?? ""
                let postLink = feedItem.Element("link")?.Value ?? ""
                let postDoc = ToHtmlDocument(feedItem.Element(contentNamespace + "encoded")?.Value ?? "")
                from linkNode in postDoc.DocumentNode.SelectNodes("//a")
                let linkTitle = linkNode.InnerText
                let linkHref = linkNode.Attributes["href"]?.Value
                where linkHref != null
                where linkTitle.Contains(topic)
                select new SearchResult
                {
                    PostTitle = postTitle,
                    PostLink = postLink,
                    LinkTitle = linkTitle,
                    LinkHref = linkHref
                };
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

            using (var wc = new WebClient())
            {
                return wc.DownloadString(uri);
            }
        }

    }
}
