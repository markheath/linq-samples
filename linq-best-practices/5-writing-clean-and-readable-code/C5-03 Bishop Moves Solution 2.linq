<Query Kind="Expression" />

// we start with a Bishop on c6
// what positions can it reach in one move?
// output should include b5, a4, b7, a8
Enumerable.Range('a', 8)
	.SelectMany(x => Enumerable.Range('1', 8), 
		(f, r) => new { File = (char)f, Rank = (char)r })
	.Select(x => new { x.File, x.Rank, dx = Math.Abs(x.File - 'c'), dy = Math.Abs(x.Rank - '6') })
	.Where(x => x.dx == x.dy && x.dx != 0)
	.Select(x => $"{x.File}{x.Rank}")