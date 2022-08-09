<Query Kind="Program">
  <NuGetReference>HtmlAgilityPack</NuGetReference>
  <Namespace>HtmlAgilityPack</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
</Query>

void Main()
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


	/*links.Where(l => l.linkTitle.Contains("Azure"))
		.Dump("Example 1");
	links.First(l => l.linkTitle.Contains("Azure"))
		.Dump("Example 2");*/

	/*var list = links.ToList();
	Console.WriteLine($"Got {list.Count} links");
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

