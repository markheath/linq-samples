<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

// [x] Window, WindowLeft, WindowRight
var times = new [] { 20.5, 20.2, 21.3, 19.4, 20.7, 20.6, 21.5, 19.5 };

times.Window(3).Dump("Window");
times.Window(3).Select(t => t.Average(p => p)).Dump("3 day averages");

times.WindowLeft(3).Dump("WindowLeft");
times.WindowRight(3).Dump("WindowRight");