<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

// [x] Random, RandomDouble, RandomSubset, Shuffle

var people = new[] { "Ben", "Lily", "Joel", "Sam", "Annie" };
var prizes = new[] { "Football", "Paints", "Rubiks Cube", "Fart Machine", "Pinkie Pie" };

prizes.RandomSubset(3).Dump("Random prizes"); // not ordered according to input sequence
people.Shuffle().Dump("Shuffle");

// can also pass in an instance of Random
MoreEnumerable.RandomDouble().Take(5).Dump("Random Double");
MoreEnumerable.Random(10,20).Take(5).Dump("Random Int between 10 and 20"); // inclusive lower bound, exclusive upper bound