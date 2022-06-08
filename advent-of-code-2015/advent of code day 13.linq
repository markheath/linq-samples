<Query Kind="Statements">
  <NuGetReference Prerelease="true">morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

var testInput = @"Alice would gain 54 happiness units by sitting next to Bob.
Alice would lose 79 happiness units by sitting next to Carol.
Alice would lose 2 happiness units by sitting next to David.
Bob would gain 83 happiness units by sitting next to Alice.
Bob would lose 7 happiness units by sitting next to Carol.
Bob would lose 63 happiness units by sitting next to David.
Carol would lose 62 happiness units by sitting next to Alice.
Carol would gain 60 happiness units by sitting next to Bob.
Carol would gain 55 happiness units by sitting next to David.
David would gain 46 happiness units by sitting next to Alice.
David would lose 7 happiness units by sitting next to Bob.
David would gain 41 happiness units by sitting next to Carol.".Split('\n');
var realInput = File.ReadAllLines(Path.GetDirectoryName(Util.CurrentQueryPath) +
	"\\day13.txt");
var rules = realInput
	.Select(s => Regex.Match(s, @"(\w+) would (lose|gain) (\d+) happiness units by sitting next to (\w+)\.").Groups.Cast<Group>().Skip(1).Select(g => g.Value).ToArray())
	.Select(p => new { A = p[0], B = p[3], Gain = int.Parse(p[2]) * (p[1] == "lose" ? -1 : 1) });
var people = rules.Select(r => r.A).Distinct().ToList();
var lookup = rules.ToDictionary(r => $"{r.A}-{r.B}", r => r.Gain);
//lookup.Dump();

// part B add me
people.ForEach(p => { lookup[$"Mark-{p}"] = 0; lookup[$"{p}-Mark"] = 0; });
people.Add("Mark");

people.Skip(1).Permutations()
	.Select(p => p.Prepend((people[0])).Concat(people[0]).Pairwise((a, b) => new { a, b }))
	.Select(p => new
	{
		Plan = p,
		Happiness = p.Sum(x => lookup[$"{x.a}-{x.b}"] + lookup[$"{x.b}-{x.a}"]) })
	.MaxBy(p => p.Happiness)
	.Dump(); // a = 664, b = 640