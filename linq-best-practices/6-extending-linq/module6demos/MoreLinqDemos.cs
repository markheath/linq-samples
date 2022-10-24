using MoreLinq;

public static class Module6MoreLinqDemos
{
    public static void CountPetsMoreLinq()
    {
        "Dog,Cat,Rabbit,Dog,Dog,Lizard,Cat,Cat,Dog,Rabbit,Guinea Pig,Dog"
        .Split(',')
        .CountBy(x => x switch { "Dog" or "Cat" => x, _ => "other" })
        .Dump();
    }

    // clip 7
    public static void BatchExample()
    {
        Enumerable.Range(1,10)
	        .Batch(3)
            .Dump();
    }

    public static void BatchFileExample()
    {
        File.ReadAllLines("questions.txt")
            .Batch(7, b => b.ToArray())
            .Select(b => new { 
                Key = b[0], 
                Question = b[1], 
                CorrectAnswer = b[2], 
                WrongAnswer1 = b[3], 
                WrongAnswer2 = b[4], 
                WrongAnswer3 = b[5] 
            })
            .Dump();
    }

    // clip 8
    public static void ConsecutiveSalesSolutionMoreLinq()
    {
        new[] { 0, 1, 3, 0, 0, 2, 1, 5, 4, 0, 0, 0, 3 }
        .GroupAdjacent(n => n > 0)
        .Where(g => g.Key)
        .Max(g => g.Count())
        .Dump();
    }
}