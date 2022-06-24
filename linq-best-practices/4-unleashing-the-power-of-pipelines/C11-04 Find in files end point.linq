<Query Kind="Statements" />

var myDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
var diagsFolder = Path.Combine(myDocs, "SkypeVoiceChanger", "diags");
var fileType = "*.csv";
var searchTerm = "User Submitted";
Directory.EnumerateFiles(diagsFolder, fileType)
	.SelectMany(file => File.ReadAllLines(file)
		.Select((line, index) => new
		{
			File = file,
			Text = line,
			LineNumber = index + 1
		})
	)
	.Where(line => Regex.IsMatch(line.Text, searchTerm))
	.Take(10)
	.Dump();