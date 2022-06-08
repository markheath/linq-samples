<Query Kind="Program" />

void Main()
{
	Enumerable.Range(1,20)
		.Select((item, index) => new { item, index })
		.GroupBy(x => x.index / 3)
		.Select(g => g.Select(x => x.item).ToArray())
		.Dump("Batch 1");

	Enumerable.Range(1, 20)
		.Batch(3)
		.Dump("Batch 2");
}

public static class MyExtensions
{
	public static IEnumerable<T[]> Batch<T>(this IEnumerable<T> source, int size)
	{
		var tmp = new List<T>();
		foreach (var item in source)
		{
			tmp.Add(item);
			if (tmp.Count == size)
			{
				yield return tmp.ToArray();
				tmp.Clear();
			}
		}
		if (tmp.Count > 0)
			yield return tmp.ToArray();
	}

}