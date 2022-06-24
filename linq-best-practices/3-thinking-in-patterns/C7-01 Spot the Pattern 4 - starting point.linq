<Query Kind="Program" />

void Main()
{
	var paths = new[] { "c:\\windows\\notepad.exe", "c:\\windows\\regedit.exe", "c:\\windows\\explorer.exe" };
	GetListOfFileSizes(paths).Dump();


List<long> GetListOfFileSizes(IEnumerable<string> paths)
{
	var fileSizes = new List<long>();
	foreach (var path in paths)
	{
		var length = new FileInfo(path).Length;
		fileSizes.Add(length);
	}
	return fileSizes;
}
