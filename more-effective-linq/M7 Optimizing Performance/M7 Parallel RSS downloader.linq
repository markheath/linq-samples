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
	XNamespace contentNamespace = "http://purl.org/rss/1.0/modules/content/";
	var links = from xdoc in sites.AsParallel()
		.Select(LoadHtml)
		.Select(ToHtmlDocument)
		.Select(GetRssFeed)
		.Select(rss => XDocument.Load(rss))
	from feedItem in xdoc.Descendants("item")	
		let postTitle = feedItem.Element("title").Value
		let postLink = feedItem.Element("link").Value
		let postDoc = ToHtmlDocument(feedItem.Element(contentNamespace + "encoded").Value)
	from linkNode in postDoc.DocumentNode.SelectNodes("//a")
        let linkTitle = linkNode.InnerText
		let linkHref = linkNode.Attributes["href"]?.Value
	where linkHref != null
	select new { postTitle, postLink, linkTitle, linkHref };
	
	links.Where(l => l.linkTitle.Contains("Angular") || 
				l.linkTitle.Contains("Azure"))
				.GroupBy(l => l.linkTitle.Contains("Angular") ? "Angular":"Azure")
				.Dump();
	
	/*
	var list = links.ToList();	
	list
		//.Where(l => l.linkTitle.Contains("LINQ"))
		.First(l => l.linkTitle.Contains("LINQ"))
		.Dump();*/
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

private static string LoadHtml(string uri)
{
	Console.WriteLine($"Loading: {uri}");

	using (var wc = new WebClient())
	{
		return wc.DownloadString(uri);
	}
}