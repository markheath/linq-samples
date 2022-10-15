<Query Kind="Program" />

void Main()
{
	var input = new[] {5, 20, 30, 38 };
	input
		.SelectMany(n => new [] { n, n })
		.Skip(1)
		.Select((item,index) => new { item, index })
		.GroupBy(x => x.index/2)
		.Select(g => g.Select(x => x.item).ToArray())
		.Where(a => a.Length > 1)
		.Select(x => x[1]-x[0])
		.Dump("DIY");

	input.Pairwise((a, b) => b-a).Dump("Pairwise");
}

static class MyExtensions
{
	public static IEnumerable<TOut> Pairwise<TSource,TOut>(this IEnumerable<TSource> items, 
		Func<TSource,TSource,TOut> selector)
	{
		// get the first item
		var e = items.GetEnumerator();
		TSource a;
		if (e.MoveNext())
		{
			a = e.Current;
			while (e.MoveNext())
			{
				yield return selector(a, e.Current);
				a = e.Current;
			}
		}
	}
}
// You can define other methods, fields, classes and namespaces here