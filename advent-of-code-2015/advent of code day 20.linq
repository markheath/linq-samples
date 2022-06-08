<Query Kind="Statements" />

Func<int,int> presentsForHouse = house => Enumerable.Range(1,house)
										.Where(elf => house % elf == 0)
										.Sum() * 10;
Func<int, int> presentsForHouseB = house => Enumerable.Range(1, house)
										 .Where(elf => house % elf == 0 && house / elf <= 50)
										 .Sum() * 11;
//Enumerable.Range(900000, 10).Select(h => new { House = h, Presents = presentsForHouse(h) }).Dump();

var fact = (2*3*5*7*11);
Enumerable.Range(1, 10000000)
	.Where(n => n % fact == 0)
	.Select(h => new { House = h, Presents = presentsForHouse(h) })
	.First(h => h.Presents >= 36000000).Dump("a");

// House = 831600, Presents = 36902400 

//Enumerable.Range(700000, 100).Select(h => new { House = h, Presents = presentsForHouseB(h) }).Dump();

var factB = (2 * 2 * 2 * 3 * 3);
Enumerable.Range(700000, 10000000)
	.Where(n => n % factB == 0)
	.Select(h => new { House = h, Presents = presentsForHouseB(h) })
	.First(h => h.Presents >= 36000000).Dump("b");
// 884520
// 887040 - too high
// 900900 - too high