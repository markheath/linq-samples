<Query Kind="Program" />

void Main()
{
	// we start with a Bishop on c6
	// what positions can it reach in one move?
	// output should include b5, a4, b7, a8
	var chessBoardPositions = Enumerable.Range('a',8)
		.SelectMany(x => Enumerable.Range('1', 8),
			(f, r) => new { File = (char)f, Rank = (char)r });

	var validMoves = chessBoardPositions
		.Where(x => BishopCanMoveTo(new { File = 'c', Rank = '6' }, x))
		.Select(x => string.Format("{0}{1}",x.File,x.Rank));
	
	validMoves.Dump();
}

bool BishopCanMoveTo(dynamic startingPosition, dynamic targetLocation)
{
	var dx = Math.Abs(startingPosition.File - targetLocation.File);
	var dy = Math.Abs(startingPosition.Rank - targetLocation.Rank);
	return dx == dy && dx != 0;

}
