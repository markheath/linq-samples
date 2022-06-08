<Query Kind="Statements" />

var strings = new List<string>() { "Ben", "Lily", "Joel", "Sam", "Annie" };
strings.Select(s => s.ToUpper());
var uppercase = strings
	.Select(s => { Console.WriteLine(s); return s.ToUpper(); })
	.Where(s => s.Length>3)
	.ToList();
foreach (var upper in uppercase)
{
	Console.WriteLine(upper);
}