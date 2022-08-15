<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

GetMessages(10).Dump();

IEnumerable<string> GetMessages(int count)
{
	for (var n = 0; n < count; n++)
	{
		var message = GetMessage(n);
		yield return message;
	}
}

async Task<string> GetMessageAsync(int n)
{
	await Task.Delay(100); // simulate
	return $"Hello world {n+1}";
}