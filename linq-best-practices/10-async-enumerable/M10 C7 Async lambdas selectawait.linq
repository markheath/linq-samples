<Query Kind="Statements">
  <NuGetReference>System.Linq.Async</NuGetReference>
  <Namespace>System.Runtime.CompilerServices</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var messages = GetMessages(10)
				.WhereAwait(async m => await CalculateSentiment(m) > 5)
				.SelectAwait(async m => await TranslateMessage(m));

await foreach (var message in messages)
{
	Console.WriteLine(message);
}

async Task<string> TranslateMessage(string message)
{
	await Task.Delay(500); // simulate a network call
	return message.Replace("Hello", "Bonjour")
			.Replace("world", "le monde");
}

async Task<int> CalculateSentiment(string message)
{
	await Task.Delay(500); // simulate a network call
	return Random.Shared.Next(0,10);
}

async IAsyncEnumerable<string> GetMessages(int count)
{
	for (var n = 0; n < count; n++)
	{
		var message = await GetMessageAsync(n);
		yield return message;
	}
}

async Task<string> GetMessageAsync(int n)
{
	await Task.Delay(500); // simulate a network call
	return $"Hello world {n + 1}";
}