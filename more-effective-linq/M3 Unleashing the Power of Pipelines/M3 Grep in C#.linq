<Query Kind="Statements" />

var folder = @"C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Include";
var searchPattern = "*.h";
var searchTerm = "IMFAsyncResult";

// grep with selectmany & chained filters
Directory.EnumerateFiles(folder, searchPattern, SearchOption.AllDirectories)
	.SelectMany(file => File.ReadAllLines(file)
							.Select((text, n) => new { text, lineNumber = n + 1, file }))
	.Where(line => Regex.IsMatch(line.text, searchTerm))
	.Take(10)
	.Dump();