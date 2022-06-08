<Query Kind="Statements" />

Enumerable.Range('a', 8)
.SelectMany(x => Enumerable.Range('1', 8), (r, c) => new { r, c })
.Select(x => new { x.r, x.c, dx = Math.Abs(x.r - 'c'), dy = Math.Abs(x.c - '6') })
.Where(x => x.dx == x.dy && x.dx != 0)
.Select(x => $"{(char)x.r}{(char)x.c}")


from row in Enumerable.Range('a', 8)
from col in Enumerable.Range('1', 8)
let dx = Math.Abs(row - 'c')
let dy = Math.Abs(col - '6')
where dx == dy && dx != 0
select $"{(char)row}{(char)col}"