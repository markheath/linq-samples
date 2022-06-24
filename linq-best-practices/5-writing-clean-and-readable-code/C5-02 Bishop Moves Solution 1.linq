<Query Kind="Expression" />

// we start with a Bishop on c6
// what positions can it reach in one move?
// output should include b5, a4, b7, a8
Enumerable.Range('a', 8)
	.SelectMany(x => Enumerable.Range('1', 8),
				(f, r) => new { File = (char)f, Rank = (char)r })
	.Where(x => Math.Abs(x.File - 'c') == Math.Abs(x.Rank - '6'))
	.Where(x => x.File != 'c')
	.Select(x => $"{x.File}{x.Rank}")
