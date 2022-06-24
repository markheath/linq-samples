<Query Kind="Expression" />

// Expand the range 
// e.g. "2,3-5,7" should expand to 2,3,4,5,7
"2,3-5,7"
	.Split(',')
	.Select(x => x.Split('-'))
	.Select(p => new { First = int.Parse(p[0]), Last = int.Parse(p.Last()) })
	.SelectMany(r => Enumerable.Range(r.First, r.Last - r.First + 1))

