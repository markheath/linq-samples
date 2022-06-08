<Query Kind="Expression">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

// LINQ Challenge 3 Problem 1 Longest Sequence
// https://markheath.net/post/linq-challenge-3

"1,2,1,1,0,3,1,0,0,2,4,1,0,0,0,0,0,2,1,0,3,1,0,0,0"
.Split(',')
.GroupAdjacent(n => n == "0" ? "N" : "Y")
.Where(g => g.Key == "N")
.Max(g => g.Count())

"1,2,1,1,0,3,1,0,0,2,4,1,0,0,0,0,0,2,1,0,3,1,0,0,0"
.Split(',')
.GroupAdjacent(n => n)


// can use current, previous and index to decide on segmenting
"1,2,1,1,0,3,1,0,0,2,4,1,0,0,0,0,0,2,1,0,3,1,0,0,0"
.Split(',')
.Segment((c,p,n) => (c == "0") ^ (p == "0"))