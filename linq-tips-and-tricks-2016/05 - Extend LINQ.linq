<Query Kind="Program">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

void Main()
{

	var people = new String[] { "Ben", "Lily", "Joel", "Sam", "Annie" };
	var longestName = "";
	foreach (var person in people)
	{
		if (person.Length > longestName.Length)
		{
			longestName = person;
		}
	}

	Console.WriteLine($"{longestName} has the longest name");


	people.First(p => p.Length == people.Max(n => n.Length)).Dump("Naive");
	people.OrderByDescending(p => p.Length).First().Dump("OrderBy");

//	people.FindMax(p => p.Length).Dump("FindMax");
	people.MaxBy(p => p.Length).Dump("MaxBy");
}

static class MyExtensions
{
	public static TSource FindMax<TSource, TKey>(this IEnumerable<TSource> source, 
								Func<TSource, TKey> selector)
	{
		var comparer = Comparer<TKey>.Default;

		using (var sourceIterator = source.GetEnumerator())
		{
			if (!sourceIterator.MoveNext())
			{
				throw new InvalidOperationException("Sequence contains no elements");
			}
			var max = sourceIterator.Current;
			var maxKey = selector(max);
			while (sourceIterator.MoveNext())
			{
				var candidate = sourceIterator.Current;
				var candidateProjected = selector(candidate);
				if (comparer.Compare(candidateProjected, maxKey) > 0)
				{
					max = candidate;
					maxKey = candidateProjected;
				}
			}
			return max;
		}
	}
}

// http://markheath.net/post/advent-of-code-day13
// https://github.com/morelinq/MoreLINQ