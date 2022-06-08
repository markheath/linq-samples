<Query Kind="Program">
  <NuGetReference>HtmlAgilityPack</NuGetReference>
  <Namespace>HtmlAgilityPack</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

void Main()
{
	var sites = new[] {
		"http://www.alvinashcraft.com/",
		"http://blog.cwa.me.uk/",
		"https://sergeytihon.wordpress.com/",
		"http://blog.chrislowis.co.uk/waw.html",
	};
	
	// real code
	FindLinks(sites, "Azure", DownloadHtml).Dump();

	// unit test code
	FindLinks(sites, "Azure", s => "<html>Hello World</html>").Dump();

}

public static IEnumerable<LinkInfo> FindLinks(IEnumerable<string> sites, 
	string topic, Func<string,string> downloadAsString)
{
	XNamespace contentNamespace = "http://purl.org/rss/1.0/modules/content/";
	return from xdoc in sites
		.Select(downloadAsString)
		.Select(ToHtmlDocument)
		.Select(GetRssFeed)
		.Select(downloadAsString)
		.Select(rss => XDocument.Parse(rss))
		from feedItem in xdoc.Descendants("item")
			let postTitle = feedItem.Element("title").Value
			let postLink = feedItem.Element("link").Value
			let postDoc = ToHtmlDocument(feedItem.Element(contentNamespace + "encoded").Value)
		from linkNode in postDoc.DocumentNode.SelectNodes("//a")
			let linkTitle = linkNode.InnerText
			let linkHref = linkNode.Attributes["href"]?.Value
			where linkHref != null
			where linkTitle.Contains(topic)
		select new LinkInfo(postTitle, postLink, linkTitle, linkHref);
}

public class LinkInfo
{
	public LinkInfo(string postTitle, string postLink, string linkTitle, string linkHref)
	{
		PostTitle = postTitle;
		PostLink = postLink;
		LinkTitle = linkTitle;
		LinkHref = linkHref;
	}
	public string PostTitle { get; }
	public string PostLink { get; }
	public string LinkTitle { get; }
	public string LinkHref { get; }
}


private static string GetRssFeed(HtmlDocument htmlDoc)
{
	return htmlDoc.DocumentNode
		.SelectNodes("//link[(@type='application/rss+xml' or @type='application/atom+xml') and @rel='alternate']")?
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
	Console.WriteLine($"Loading: {uri}");

	using (var wc = new WebClient())
	{
		return wc.DownloadString(uri);
	}
}