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

	// real code
	//FindLinks(sites, "Azure", DownloadHtml).Dump();

	// unit test code
	FindLinks(sites, "Azure", s => "<html>Hello World</html>").Dump();

}

static IEnumerable<LinkInfo> FindLinks(IEnumerable<string> sites, 
	string topic, Func<string,string> downloadAsString)
{
	XNamespace contentNamespace = "http://purl.org/rss/1.0/modules/content/";
	return from xdoc in sites
				.Select(downloadAsString)
				.Select(ToHtmlDocument)
				.Select(GetRssFeed)
				.Where(feed => feed != null)
				.Select(LoadRssFeed)
			from feedItem in xdoc.Descendants("item")
				let postTitle = feedItem.Element("title").Value
				let postLink = feedItem.Element("link").Value
				let postContent = feedItem.Element(contentNamespace + "encoded")
				let html = postContent?.Value ?? downloadAsString(postLink)
				let postDoc = ToHtmlDocument(html)
			from linkNode in postDoc.DocumentNode.SelectNodes("//a")
				let linkTitle = linkNode.InnerText
				let linkHref = linkNode.Attributes["href"]?.Value
				where linkHref != null
				where linkTitle.Contains(topic)
			select new LinkInfo(postTitle, postLink, linkTitle, linkHref);
}

record LinkInfo(string postTitle, string postLink, string linkTitle, string linkHref);

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

private static HttpClient httpClient = new HttpClient();
private static string DownloadHtml(string uri)
{
	Console.WriteLine($"Downloading: {uri}");
	// note - not a recommended practice to use .Result
	// see demos later in course for a better approach
	return httpClient.GetStringAsync(uri).Result;
}
