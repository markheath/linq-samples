<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

var input = File.ReadAllLines(
	Path.GetDirectoryName(Util.CurrentQueryPath) +
	"\\day5.txt");

var vowels = new[] { 'a', 'e', 'i', 'o', 'u' };
var naughtyStrings = new[] { "ab", "cd", "pq", "xy" };
Predicate<string> hasThreeVowels =
	s => s.Where(c => vowels.Any(v => c == v))
			.Take(3)
			.Count() == 3;
Predicate<string> hasDoubleLetter =
	s => s.Pairwise((a, b) => a == b).Any(x => x);
Predicate<string> containsNaughtyString =
	s => naughtyStrings.Any(n => s.Contains(n));
Predicate<string> isNice =
	s => hasThreeVowels(s) && hasDoubleLetter(s) && !containsNaughtyString(s);

input
	.Where(s => isNice(s))
	.Count()
.Dump("a"); // a = 236

//"aabcdebccfaa"
Predicate<string> containsNonOverlappingPair = s => s
	.Select((c, n) => new { c, n })
	.Pairwise((a, b) => new
	{
		s = new string(new[] { a.c, b.c }),
		n = a.n
	})
	.GroupBy(p => p.s)
	.Where(g => g.Count() > 1
		&& g.Any(v => v.n - g.First().n > 1))
	.Any();

Predicate<string> containsDuplicateSeparatedByOne = s => s
	.Select((c, n) => new { c, n })
	.GroupBy(p => p.c)
	.Where(g => g.Count() > 1 
	&& g.Pairwise((a,b) => a.n + 2 == b.n).Any(c => c))
	.Any();

Predicate<string> isNiceB = s =>
	containsNonOverlappingPair(s) && containsDuplicateSeparatedByOne(s);
	
// test cases
isNiceB("qjhvhtzxzqqjkmpb").Dump();
isNiceB("xxyxx").Dump();
isNiceB("uurcxstgmygtbstg").Dump();
isNiceB("ieodomkazucvgmuy").Dump();

input
	.Where(s => isNiceB(s))
	.Count()
.Dump("b"); // b = 51