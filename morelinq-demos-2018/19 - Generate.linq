<Query Kind="Expression">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

// Generate, GenerateByIndex, Sequence, Unfold, Repeat

MoreEnumerable.Generate(3, c => c * 4).Take(5)
MoreEnumerable.GenerateByIndex(i => $"Item {i}").Take(5)
MoreEnumerable.Sequence(5,10)
MoreEnumerable.Sequence(5,10,2)
MoreEnumerable.Repeat(new [] {"A","B","C"}, 4)
MoreEnumerable.Repeat(new [] {"A","B","C"}).Take(10) 

// initial state
// "generator" -> calculates temporary intermediate state used as input to next three functions:
// "predicate" -> decides if we should keep going
// "stateSelector" -> calculates the next state
// "resultSelector" -> calculates the next result
MoreEnumerable.Unfold((a:0,b:1), s => s, s => s.a < 30, s => (s.b, s.a + s.b), s => s.a + s.b)