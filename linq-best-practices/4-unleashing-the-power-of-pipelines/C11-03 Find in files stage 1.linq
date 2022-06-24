<Query Kind="Statements" />

var myDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
var diagsFolder = Path.Combine(myDocs, "SkypeVoiceChanger", "diags");
var fileType = "*.csv";
var searchTerm = "User Submitted";
Directory.EnumerateFiles(diagsFolder, fileType)
	.SelectMany(file => File.ReadAllLines(file))
	.Where(line => Regex.IsMatch(line, searchTerm))
	.Dump();