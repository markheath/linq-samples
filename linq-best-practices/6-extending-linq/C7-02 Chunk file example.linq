<Query Kind="Expression" />

File.ReadAllLines(Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath),"questions.txt"))
	.Chunk(7)
	.Select(b => new { 
		Key = b[0], 
		Question = b[1], 
		CorrectAnswer = b[2], 
		WrongAnswer1 = b[3], 
		WrongAnswer2 = b[4], 
		WrongAnswer3 = b[5] 
})
