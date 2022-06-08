<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

// RunLengthEncode
"AAABBCCCAA".RunLengthEncode().Dump("Run Length Encode"); // also supports a custom comparer

"AAAAAAAAABBBBBBBBBCCCCCCCAAAAAAA".RunLengthEncode().Select(kvp => $"{kvp.Key}{kvp.Value}").ToDelimitedString("").Dump("Run Length Encode");

// look and say sequence
"13112221".RunLengthEncode().Select(g => $"{g.Value}{g.Key}").ToDelimitedString("")