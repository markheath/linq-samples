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
	// note: we're only using Send here to avoid having to block on async menthods
	// later in the course we'll see how to use async methods in a LINQ pipeline
	var resp = httpClient.Send(new HttpRequestMessage(HttpMethod.Get, uri));
	using var streamReader = new StreamReader(resp.Content.ReadAsStream());
	return streamReader.ReadToEnd();
}



