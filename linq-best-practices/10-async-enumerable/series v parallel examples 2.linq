<Query Kind="Statements">
  <NuGetReference>System.Linq.Async</NuGetReference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var files = new[] { "file1.txt", "file2.txt", "file3.txt" };
var corruptFiles = files
	.ToAsyncEnumerable()
	.SelectAwait(async f => await GetFileInfo(f))
	.WhereAwait(async f => await IsCorruptAsync(f));
await foreach (var f in corruptFiles)
{
	//...
}

Console.WriteLine("BEGIN PARALLEL 1");
var tasks = GetOrders().Select(async o => await ProcessOrder(o));
await Task.WhenAll(tasks);
Console.WriteLine("END PARALLEL 1");
Console.WriteLine("BEGIN PARALLEL 2");
var tasks2 = await GetOrders2().Select(async o => await ProcessOrder(o)).ToListAsync();
await Task.WhenAll(tasks2);
Console.WriteLine("END PARALLEL 2");

Task<FileInfo> GetFileInfo(string path)
{
	return Task.FromResult(new FileInfo(path));
}

Task<bool> IsCorruptAsync(FileInfo fileInfo)
{
	return Task.FromResult(false);
}

IEnumerable<string> GetOrders() {
	return Enumerable.Range(1,10).Select(n => $"Order {n}");
}

IAsyncEnumerable<string> GetOrders2()
{
	return GetOrders().ToAsyncEnumerable();
}

async Task ProcessOrder(string order)
{
	Console.WriteLine($"Started processing order {order}");
	await Task.Delay(TimeSpan.FromSeconds(1));
	Console.WriteLine($"Completed processing order {order}");	
}