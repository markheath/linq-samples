<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

// [x] Equizip
// ZipLongest
// ZipShortest

var people = new[] { "Ben", "Lily", "Joel", "Sam", "Annie" };
var prizes = new[] { "Football", "Paints", "Rubiks Cube", "Fart Machine", "Pinkie Pie" };

people.Zip(prizes, (w, p) => $"{w} wins a {p}").Dump("LINQ zip");
people.EquiZip(prizes, (w, p) => $"{w} wins a {p}").Dump("EquiZip");

var crisps = new[] { "Salt and Vinegar", "Cheese and Onion", "Ready Salted" };
people.Zip(crisps, (p, c) => $"{p} gets {c} crisps").Dump("LINQ zip Different length"); // same result with crisps.Zip(people)

// will get sequence too short
//people.EquiZip(crisps, (p,c) => $"{p} gets {c} crisps").Dump("EquiZip");

people.ZipShortest(crisps, (p, c) => $"{p} gets {c} crisps").Dump("ZipShortest"); // same result with crisps.ZipShortest(people)
people.ZipLongest(crisps, (p, c) => $"{p} gets {c} crisps").Dump("ZipLongest");