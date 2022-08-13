<Query Kind="Statements" />

var numbers = Enumerable.Range(1, 10)
				.Select(n => 5 - n);
				
try
{
	numbers = numbers.Select(n => 10 / n);
}
catch (Exception e)
{
	Console.WriteLine($"Error: {e.Message}");
}

foreach (var n in numbers)
{
	Console.WriteLine(n);
}
