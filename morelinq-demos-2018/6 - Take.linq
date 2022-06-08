<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

// [x] TakeEvery, TakeLast, TakeUntil

var players = new [] { "Aubameyang", "Ramsey", "Xhaka", "Ozil", "Koscielny", "Bellerin", "Mustafi", "Elneny" };
players.Take(4).Dump("LINQ Take");
players.TakeWhile(p => p.Length > 4).Dump("LINQ TakeWhile");

players.TakeLast(4).Dump("TakeLast"); // can return fewer items if the input sequence is not long enough
players.TakeUntil(p => p.StartsWith("B")).Dump("TakeUntil"); // includes the first matched item
players.TakeEvery(3).Dump("TakeEvery"); // first item 

// sampling with TakeEvery https://markheath.net/post/linq-challenge-2-solution-csharp

// difference between TakeWhile and TakeUntil
//"AAABBB".TakeWhile(c => c == 'A')
//"AAABBB".TakeUntil(c => c != 'A')