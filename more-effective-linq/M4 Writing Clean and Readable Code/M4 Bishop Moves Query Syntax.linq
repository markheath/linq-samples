<Query Kind="Expression" />

from row in Enumerable.Range('a', 8)
from col in Enumerable.Range('1', 8)
let dx = Math.Abs(row - 'c')
let dy = Math.Abs(col - '6')
where dx == dy
where dx != 0
select String.Format("{0}{1}", (char)row, (char)col)