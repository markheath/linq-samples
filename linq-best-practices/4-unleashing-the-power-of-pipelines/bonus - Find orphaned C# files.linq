<Query Kind="Program" />

void Main()
{
	var sourceFolder = @"C:\Users\Mark\code\github\NAudio";

	var allCSharpFiles =
		Directory.EnumerateFiles(sourceFolder, "*.cs", SearchOption.AllDirectories)
		.Where(p => !p.Contains(@"\obj\"))
		.Where(p => !p.Contains(@"\bin\"))
		.ToList();

	var allCSharpFilesInProjects =
		Directory.EnumerateFiles(sourceFolder, "*.csproj", SearchOption.AllDirectories)
		.FindCSharpFiles()
		.ToList();

	allCSharpFiles.Except(allCSharpFilesInProjects)
		.Dump("C# files not in projects");
}

static class MyExtensions
{
	public static IEnumerable<string> FindCSharpFiles(
		this IEnumerable <string> projectPaths)
	{
		string xmlNamespace = "{http://schemas.microsoft.com/developer/msbuild/2003}";

		return from projectPath in projectPaths
			   let xml = XDocument.Load(projectPath)
			   let dir = Path.GetDirectoryName(projectPath)
			   from c in xml.Descendants(xmlNamespace + "Compile")
			   let inc = c.Attribute("Include").Value
			   where inc.EndsWith(".cs")
			   select Path.Combine(dir, c.Attribute("Include").Value);
	}
}