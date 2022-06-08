<Query Kind="Statements" />

var numbers = Enumerable.Range(1, 10)
				.Select(n => 5 - n)
				.Select(n =>
				{
					try
					{
						return 10 / n;
					}
					catch (Exception e)
					{
						Console.WriteLine($"Error in lambda: {e.Message}");
						ewru
					}
				});

foreach (var n in numbers)
{
	Console.WriteLine(n);
}
