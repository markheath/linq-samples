<Query Kind="Statements" />

/*var clues1 = @"children: 3,cats: 7,samoyeds: 2,pomeranians: 3,akitas: 0,vizslas: 0,goldfish: 5,trees: 3,cars: 2,perfumes: 1"
			.Split(',')
			.Select(s => s.Split(':'))
			.ToDictionary(k => k[0], v => int.Parse(v[1].Trim()));*/
Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath));

var clues = new Dictionary<string, int> {
	["children"] = 3, ["cats"] = 7,	["samoyeds"] = 2, ["pomeranians"] = 3, ["akitas"] = 0,
	["vizslas"] = 0, ["goldfish"] = 5, ["trees"] = 3, ["cars"] = 2, ["perfumes"] = 1 };

var sues = File.ReadAllLines("day16.txt")
	.Select(r => Regex.Matches(r, @"(\w+)\: (\d+)")
					.Cast<Match>()
					.Select(m => m.Groups.Cast<Group>().Select(g=>g.Value).Skip(1).ToArray())
					.ToDictionary(g => g[0],g => int.Parse(g[1])))
	.ToArray();

sues.Select((s, n) => new
{
	Sue = n + 1,
	Match = clues.All(kvp => !s.ContainsKey(kvp.Key) || s[kvp.Key] == kvp.Value)
}).Single(x => x.Match).Sue.Dump("a"); //213

sues.Select((s, n) => new
{
	Sue = n + 1,
	Match = clues.All(kvp =>
	!s.ContainsKey(kvp.Key) || 
	((kvp.Key == "cats" || kvp.Key == "trees") ? s[kvp.Key] > kvp.Value :
	(kvp.Key == "pomeranians" || kvp.Key == "goldfish") ? s[kvp.Key] < kvp.Value :	
	s[kvp.Key] == kvp.Value))
}).Single(x => x.Match).Sue.Dump("b");


// OR - other way round thanks to Jeff, avoid checking if key contains
sues.Select((s, n) => new
{
	Sue = n + 1,
	Match = s.All(kvp =>
	(kvp.Key == "cats" || kvp.Key == "trees") ? clues[kvp.Key] < kvp.Value :
	(kvp.Key == "pomeranians" || kvp.Key == "goldfish") ? clues[kvp.Key] > kvp.Value :
	clues[kvp.Key] == kvp.Value)
}).Single(x => x.Match).Sue.Dump("b2");