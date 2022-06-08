<Query Kind="Statements" />

Func<string, long> fromBase26String = s => s.Reverse().Aggregate(new { sum = 0L, mult = 1L }, 
	(acc, next) => new { sum = acc.sum + (next - 'a') * acc.mult, mult = acc.mult * 26 }).sum;

var chars = Enumerable.Range('a', 26).Select(n => (char)n).ToArray();
Func<long, string> toBase26String = n =>
{
    var s = ""; do { s = chars[n % 26] + s; n /= 26; } while (n > 0); return s;
};
Func<string, string> incrementPassword = p => toBase26String(fromBase26String(p) + 1);
//incrementPassword("abc").Dump();
//incrementPassword("abz").Dump();
//incrementPassword("azz").Dump();


Func<string, bool> containsIncreasingSequence = s => Enumerable.Range(0,s.Length-2)
	.Select(n => s.Substring(n,3))
	.Any(q => (q[0] + 1 == q[1]) && (q[1] + 1) == q[2]);

Func<string,bool> containsNaughtyLetters = s => s.Any(c => c == 'i' || c == 'o' || c == 'l');
Func<string,bool> containsTwoNonOverlappingPairs = s => Regex.IsMatch(s, @"(\w)\1.*(\w)\2");

Func<string, bool> containsTwoNonOverlappingPairs2 = s =>
     Regex.Matches(s, @"(\w)\1").Cast<Match>().Select(m => m.Value).Distinct().Count() > 1;


/*containsTwoNonOverlappingPairs("hello").Dump();
containsTwoNonOverlappingPairs("aaxaa").Dump();
containsTwoNonOverlappingPairs("aaxab").Dump();
containsTwoNonOverlappingPairs("aaxbb").Dump();
containsTwoNonOverlappingPairs("aabb").Dump();

containsIncreasingSequence("hello").Dump();
containsIncreasingSequence("abc").Dump();
containsIncreasingSequence("aabc").Dump();
containsIncreasingSequence("abeabfefg").Dump();*/

Func<string,bool> isValidPassword = pw => !containsNaughtyLetters(pw) && 
											containsIncreasingSequence(pw) && 
											containsTwoNonOverlappingPairs(pw);

//isValidPassword("hijklmmn").Dump();
//isValidPassword("abbceffg").Dump();
//isValidPassword("abbcegjk").Dump();

// todo - try with MoreLinq.Generate
Func<string, string> findNextPassword = start =>
{
	var startVal = fromBase26String(start);
 	return Enumerable.Range(1, 10000000)
 			.Select(n => startVal + n)
	 		.Select(n => toBase26String(n))
	 		.First(p => isValidPassword(p)); };

//Math.Pow(26,8).Dump();
(findNextPassword("abcdefgh") == "bcdffaa").Dump("test1"); // bcdffaa
(findNextPassword("ghijklmn") == "ghjaabcc").Dump("test2"); // ghjaabcc

findNextPassword("vzbxkghb").Dump("a");// vzbxxyzz
findNextPassword("vzbxxyzz").Dump("b"); // vzcaabcc

// n.b. I don't bother to pad with leading 'a'

// interesting fast methods for arbitrary base conversions:
//http://www.pvladov.com/2012/05/decimal-to-arbitrary-numeral-system.html
//http://www.pvladov.com/2012/07/arbitrary-to-decimal-numeral-system.html