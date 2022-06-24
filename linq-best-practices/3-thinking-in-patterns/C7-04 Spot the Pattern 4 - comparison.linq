<Query Kind="Program" />

void Main()
{
	var paths = new[] { "c:\\windows\\notepad.exe", "c:\\windows\\regedit.exe", "c:\\windows\\explorer.exe" };
	GetListOfFileSizes(paths).Dump();
	
	var lookup = paths.Select(p => new FileInfo(p).Length).ToDictionary(p => p);
	lookup.Dump("Dictionary");
}

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

List<long> GetListOfFileSizesLinq(IEnumerable<string> paths)
{
	return paths.Select(p => new FileInfo(p).Length).ToList();
}