<Query Kind="Statements" />

var target = 36000000;
var houses = new int[target/10 + 1];
for (int elf = 1; elf < houses.Length; elf++)
    for (int house = elf; house < houses.Length; house+=elf)
        houses[house] += elf * 10;
for (int house = 1; house < houses.Length; house++)
	if (houses[house] > target) { house.Dump("a"); break; }

houses = new int[target/11 + 1];
for (int elf = 1; elf < houses.Length; elf++)
	for (int house = elf, n = 0; house < houses.Length && n < 50; house+=elf, n++)
		houses[house] += elf * 11;
for (int house = 1; house < houses.Length; house++)
	if (houses[house] > target) { house.Dump("b"); break; }