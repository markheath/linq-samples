<Query Kind="Expression" />

File.ReadAllText(
	Path.GetDirectoryName(Util.CurrentQueryPath) +
	"\\day1.txt")
    .Sum(c => c == '(' ? 1 : -1)