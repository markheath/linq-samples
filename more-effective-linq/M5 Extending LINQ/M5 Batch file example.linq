<Query Kind="Expression">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

File.ReadAllLines(@"c:\users\mark\desktop\questions.txt")
	.Batch(7, b => b.ToArray())
	.Select(b => new { 
		Key = b[0], 
		Question = b[1], 
		CorrectAnswer = b[2], 
		WrongAnswer1 = b[3], 
		WrongAnswer2 = b[4], 
		WrongAnswer3 = b[5] 
})
