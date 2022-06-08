<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

// Pad and PadStart

var prizes = new[] { "Football", "Paints", "Rubiks Cube", "Fart Machine", "Pinkie Pie" };

prizes.Pad(10).Dump("Pad to 10");
prizes.Pad(3).Dump("Pad to 3");
prizes.Pad(10, "No prize").Dump("Pad to 10 with value");
prizes.Pad(10, n => $"Prize {n}").Dump("Pad with value generator");

prizes.PadStart(10, "No prize").Dump("Pad to 10 start"); // has same 3 overloads

