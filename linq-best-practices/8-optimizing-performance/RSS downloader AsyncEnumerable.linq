<Query Kind="Program">
  <NuGetReference>HtmlAgilityPack</NuGetReference>
  <NuGetReference>System.Linq.Async</NuGetReference>
  <Namespace>HtmlAgilityPack</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var sites = new[] {
		"https://www.alvinashcraft.com/", // Alvin Ashcraft Morning Dew
		"https://blog.cwa.me.uk/", // Chris Alcock Morning Brew
		"https://sergeytihon.com/", // Sergey Tihon F# Weekly
		"https://www.webaudioweekly.com/", // Chris Lowis Web Audio Weekly
	};
	sites
		.ToAsyncEnumerable()
		.SelectAwait(async url => await DownloadHtml(url))
		.Select(ToHtmlDocument)
		.Select(GetRssFeed)
		.SelectAwait(async f => await LoadRssFeed(f))
		.SelectMany(feed => GetFeedsFromXDoc(feed))
		.Where(l => l.LinkTitle.Contains("Azure") ||
				l.LinkTitle.Contains("Blazor"))
		.GroupBy(l =>l.LinkTitle.Contains("Blazor") ? "Blazor":"Azure")
		.Dump("Blazor and Angular");

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
		var html = postContent?.Value ?? await DownloadHtml(postLink);
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


static HttpClient xmlClient = BuildXmlClient();

private static HttpClient BuildXmlClient()
{
	var c = new HttpClient();
	c.DefaultRequestHeaders.Accept.
		Add(new MediaTypeWithQualityHeaderValue("application/xml"));
	return c;
}

private static async Task<XDocument> LoadRssFeed(string rssFeedLink)
{
	// XDocument.Load doesn't follow 307 redirects (feedburner)
	var resp = xmlClient.GetAsync(rssFeedLink).Result;
	if (resp.StatusCode == HttpStatusCode.TemporaryRedirect)
	{
		resp = xmlClient.GetAsync(resp.Headers.GetValues("Location").First()).Result;
	}
	var xml = await resp.Content.ReadAsStringAsync();
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
private static Task<string> DownloadHtml(string uri)
{
	Console.WriteLine($"Downloading: {uri}");
	return httpClient.GetStringAsync(uri);	
}

