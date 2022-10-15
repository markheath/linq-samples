<Query Kind="Program" />

void Main()
{
	var messages = GetMessages();
	Console.WriteLine(messages.First());
}

IEnumerable<string> GetMessages()
{
	yield return "Hello";
	Thread.Sleep(5000);
	yield return "World";
	throw new Exception("Blah");
}
