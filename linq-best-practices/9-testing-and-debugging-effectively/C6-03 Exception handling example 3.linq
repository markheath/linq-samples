<Query Kind="Statements" />

var numbers = Enumerable.Range(1, 10)
				.Select(n => 5 - n)
				.Select(n => 10 / n);
try
{
	foreach (var n in numbers)
	{
		Console.WriteLine(n);
	}
}
catch (Exception e)
{
	Console.WriteLine($"Error in foreach loop: {e.Message}");
}

