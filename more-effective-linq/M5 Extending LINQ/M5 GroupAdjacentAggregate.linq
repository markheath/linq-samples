<Query Kind="Expression" />

new[] { 0, 1, 3, 0, 0, 2, 1, 5, 4, 0, 0, 0, 3 }
	.Aggregate(new { Current = 0, Max = 0 }, (acc, next) =>
	{
		var c = (next > 0) ? acc.Current + 1 : 0;
		return new { Current = c, Max = Math.Max(acc.Max, c) };
	})