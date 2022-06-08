<Query Kind="Statements" />

// a chess board is an 8x8 grid, from a1 in the bottom left 
// to h8 in the top right. A bishop can travel diagonally any
// number of squares. So for example a bishop on c5 can go to
// b4 or to a3 in one move.
// create an enumerable sequence of board positions that
// includes every square a bishop can move to in one move
// on an empty chess board, if its starting position is c6
// e.g. output would include b7, a8, b5, a4

var chained = 
	Enumerable.Range('a', 8)
	.SelectMany(x => Enumerable.Range('1', 8), (r, c) => new { r, c })
	.Select(x => new { x.r, x.c, dx = Math.Abs(x.r - 'c'), dy = Math.Abs(x.c - '6') })
	.Where(x => x.dx == x.dy && x.dx != 0)
	.Select(x => String.Format("{0}{1}", (char)x.r, (char)x.c));
	
chained.Dump("Chained Extension methods");


















var queryExpression =
	from row in Enumerable.Range('a', 8)
	from col in Enumerable.Range('1', 8)
	let dx = Math.Abs(row - 'c')
	let dy = Math.Abs(col - '6')
	where dx == dy
	where dx != 0
	select String.Format("{0}{1}", (char)row, (char)col);
	
queryExpression.Dump("Query Expression");