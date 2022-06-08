<Query Kind="Program" />

void Main()
{
	var query = Enumerable.Range(5, 10)
		.Select(n => n * n)
		.Peek(n => Console.WriteLine($"Step 1: {n}"))
		.Select(n => n / 2)
		.Peek(n => Console.WriteLine($"Step 2: {n}"))
		.Select(n => n - 5);
	foreach (var n in query)
	{
		Console.WriteLine($"Output {n}");
	}
}

static class MyExtensions
{
	public static IEnumerable<T> Peek<T>(this IEnumerable<T> source, Action<T> action)
	{
		foreach (var element in source)
		{
			action(element);
			yield return element;
		}
	}
}
