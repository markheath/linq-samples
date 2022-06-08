<Query Kind="Expression" />

Regex.Matches(
File.ReadAllText(Path.GetDirectoryName(Util.CurrentQueryPath) +
	"\\day12.txt"), 
	@"[\-0-9]+")
	.Cast<Match>()
	.Select(m => m.Value)
	.Select(int.Parse)
	.Sum()