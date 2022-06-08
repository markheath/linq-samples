<Query Kind="Program">
  <Connection>
    <ID>5eb5d186-a779-490b-bfd9-ba9e62eca475</ID>
    <Persist>true</Persist>
    <Server>(localdb)\v11.0</Server>
    <Database>SuaveMusicStore</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// deferred execution
void Main()
{
	var messages = GetMessages().First();
			
}

IEnumerable<string> GetMessages()
{
	yield return "Hello";
	yield return "World";
	yield return "XX";
	throw new Exception("Blah");
}















// multiple enumeration
void SomeFunction(IEnumerable<string> fileNames)
{
	fileNames.ToArray()
	foreach (var s1 in fileNames)
	{		
		Console.WriteLine(File.ReadAllText(s1));
	}

	foreach (var s2 in fileNames)
	{
		Console.WriteLine($"{s2} is {new FileInfo(s2).Length} bytes long");
	}
	
	var longestFileName = fileNames.Max(s => s.Length);
	var shortestFileName = fileNames.Min(s => s.Length);
}















// performance and correctness
// exiting early

// see also M3 Download Diags from Azure




//var longUpperCaseMessages = messages
//	.Select(m => m.ToUpper())
//	.Where(m => m.Length > 3)
//	.ToList();
//