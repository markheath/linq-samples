<Query Kind="Program" />

void Main()
{
	var numbers = new[] { 1, 5, 3 };
	var strings = new[] { "oranges", "pears",  };
	numbers.DoubleUp().Dump();
	strings.DoubleUp().Dump();
}

static class MyExtensions
{
	public static IEnumerable<T> DoubleUp<T>(this IEnumerable<T> source)
	{
		foreach (var s in source)
		{
			yield return s;
			yield return s;
		}
	}
}