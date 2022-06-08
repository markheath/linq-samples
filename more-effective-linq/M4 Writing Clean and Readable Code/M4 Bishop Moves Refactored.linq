<Query Kind="Program" />

void Main()
{
	GetBoardPositions()
		.Where(p => BishopCanMoveTo(p,"c6"))
		.Dump();
	
}
static IEnumerable<string> GetBoardPositions()
{
	return Enumerable.Range('a', 8).SelectMany(
		x => Enumerable.Range('1', 8), (f, r) => 
			String.Format("{0}{1}",(char)f, (char)r));
}

static bool BishopCanMoveTo(string startPos, string targetPos)
{
	var dx = Math.Abs(startPos[0] - targetPos[0]);
	var dy = Math.Abs(startPos[1] - targetPos[1]);
	return dx == dy && dx != 0;
}