<Query Kind="Program">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

void Main()
{
	var books = new[] {
		new { Author = "Robert Martin", Title = "Clean Code", Pages = 464 },
		new { Author = "Oliver Sturm", Title = "Functional Programming in C#" , Pages = 270 },
		new { Author = "Martin Fowler", Title = "Patterns of Enterprise Application Architecture", Pages = 533 },
        new { Author = "Bill Wagner", Title = "Effective C#", Pages = 328 },
		};

	books.Max(b => b.Pages).Dump("Max");
	
	books.First(b => b.Pages == books.Max(x => x.Pages)).Dump("Bad!");
	
	var mostPages = books.Max(x => x.Pages);
	books.First(b => b.Pages == mostPages).Dump("Better!");
	
	books.OrderByDescending(b => b.Pages).First().Dump("Hmmm!");
	
	books.Aggregate((agg, next) => next.Pages > agg.Pages ? next : agg).Dump("Good");
	
	books.MaxBy(b => b.Pages).Dump("Best");
}

static class MyLinqExtensions
{
	public static TSource MaxBy2<TSource, TKey>(this IEnumerable<TSource> source,
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