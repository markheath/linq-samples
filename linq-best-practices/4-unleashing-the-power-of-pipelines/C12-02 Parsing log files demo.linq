<Query Kind="Statements" />

var myDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
var diagsFolder = Path.Combine(myDocs, "SkypeVoiceChanger", "diags");
var fileType = "*.csv";
Directory.EnumerateFiles(diagsFolder, fileType)
	.SelectMany(file => File.ReadAllLines(file)
			.Skip(1)
			.Select(line => line.Split(','))
			.Where(parts => parts.Length > 8))
	.Where(parts => Regex.IsMatch(parts[8], "Checking license for"))
	.Select(parts => new
	{
		Date = DateTime.Parse(parts[0]),
		License = Regex.Match(parts[8], @"\d+").Value,
		FirstTime = Regex.Match(parts[9], @"True|False").Value,
	})
	.Where(x => x.License.Length >= 6)
	.Select(e => e.License)
	.Distinct()
	.Dump();