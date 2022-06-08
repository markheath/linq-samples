<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

var input = File.ReadAllLines(
	Path.GetDirectoryName(Util.CurrentQueryPath) +
	"\\day5.txt");
var naughtyStrings = new[] { "ab", "cd", "pq", "xy" };
Predicate<string> hasThreeVowels = s => Regex.IsMatch(s, @"[aeiou].*[aeiou].*[aeiou]");
Predicate<string> hasDoubleLetter = s => Regex.IsMatch(s, @"(\w)\1+");
Predicate<string> containsNaughtyString = s => Regex.IsMatch(s, @"ab|cd|pq|xy");

Predicate<string> isNice =
	s => hasThreeVowels(s) && hasDoubleLetter(s) && !containsNaughtyString(s);

input
	.Where(s => isNice(s))
	.Count()
.Dump("a"); // a = 236


//"aabcdebccfaa"
Predicate<string> containsNonOverlappingPair = s=> Regex.IsMatch(s,@"(\w{2}).*\1+");
Predicate<string> containsDuplicateSeparatedByOne = s => Regex.IsMatch(s,@"(\w).\1");

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

// credit to mermop: https://github.com/mermop/advent-of-code-ruby/blob/master/05-01-strings.rb