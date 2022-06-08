<Query Kind="Program" />

void Main()
{
	Enumerable.Range('a', 8)
		.SelectMany(x => Enumerable.Range('1', 8), 
					(f, r) => new { File = (char)f, Rank = (char)r })
		.Where(x => Math.Abs(x.File - 'c') == Math.Abs(x.Rank - '6'))
		.Where(x => x.File != 'c')
		.Select(x => string.Format("{0}{1}",x.File, x.Rank))
		.Dump("Step 1");
	
	Enumerable.Range('a', 8)
		.SelectMany(x => Enumerable.Range('1', 8), (f, r) => new { f, r })
		.Select(x => new { x.f, x.r, dx = Math.Abs(x.f - 'c'), dy = Math.Abs(x.r - '6') })
		.Where(x => x.dx == x.dy && x.dx != 0)
		.Select(x => String.Format("{0}{1}", (char)x.f, (char)x.r))
		.Dump("Step 2 - avoid repetition of start pos");
	
	Enumerable.Range('a', 8)
		.SelectMany(x => Enumerable.Range('1', 8), (f, r) => new { f, r })
		.Where(x => BishopCanMoveTo(new { f = 'c', r = '6' }, x))
		.Select(x => String.Format("{0}{1}", (char)x.f, (char)x.r))
		.Dump("Step 3 - Bishop helper method");
}

bool BishopCanMoveTo (dynamic startPos, dynamic targetPos)
{
	var dx = Math.Abs(startPos.f - targetPos.f);
	var dy = Math.Abs(startPos.r - targetPos.r);
	return dx == dy && dx != 0;
}
