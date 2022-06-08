<Query Kind="Program" />

void Main()
{
	"Dog,Cat,Rabbit,Dog,Dog,Lizard,Cat,Cat,Dog,Rabbit,Guinea Pig,Dog"
		.Split(',')
		//.GroupBy(x => (x != "Dog" && x != "Cat") ? "Other" : x)
		//.Select(g => new { Pet = g.Key, Count = g.Count() })
		.CountBy(x => (x != "Dog" && x != "Cat") ? "Other" : x)
		.Dump();
}

static class MyLinqExtensions
{
	public static IEnumerable<KeyValuePair<TKey, int>> CountBy<TSource, TKey>(this IEnumerable<TSource> source, 
																				   Func<TSource, TKey> selector)
	{
		var counts = new Dictionary<TKey, int>();
		foreach (var item in source)
		{
			var key = selector(item);
			if (!counts.ContainsKey(key))
			{
				counts[key] = 1;
			}
			else
			{
				counts[key]++;
			}
		}
		return counts;
	}
}