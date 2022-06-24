<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>static MoreLinq.Extensions.PairwiseExtension</Namespace>
</Query>

var splitTimes = "00:45,01:32,02:18,03:01,03:44,04:31,05:19,06:01,06:47,07:35";

("00:00," + splitTimes)
	.Split(',')
	.Zip(splitTimes.Split(','),
		(s,f) => new 
		{ 
			Start = TimeSpan.Parse("00:" + s),
			Finish = TimeSpan.Parse("00:" + f),
		})
.Dump();
		
