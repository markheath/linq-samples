<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

// [x] SkipUntil and SkipLast (and Slice)

var players = new [] { "Aubameyang", "Ramsey", "Xhaka", "Ozil", "Koscielny", "Bellerin", "Mustafi", "Elneny" };
players.Skip(4).Dump("LINQ Skip");
players.SkipWhile(p => p.Length > 4).Dump("LINQ SkipWhile");

players.SkipLast(4).Dump("SkipLast"); // can return fewer items if the input sequence is not long enough
players.SkipUntil(p => p.StartsWith("B")).Dump("SkipUntil"); // doesn't include the first matched item

players.Slice(2,3).Dump("Slice");
players.Slice(7,6).Dump("Slice beyond bounds");