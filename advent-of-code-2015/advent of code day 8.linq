<Query Kind="Statements" />

File.ReadAllLines(Path.GetDirectoryName(Util.CurrentQueryPath) + "\\day8.txt")
	.Select(s => new 
	{
		Escaped = s, Unescaped =
			Regex.Replace(
			s.Substring(1, s.Length - 2)
				.Replace("\\\"", "\"")
				.Replace("\\\\", "?"),
			@"\\x[0-9a-f]{2}", "?")
		})
.Sum(s => s.Escaped.Length - s.Unescaped.Length)
.Dump("a"); // 1333

File.ReadAllLines(Path.GetDirectoryName(Util.CurrentQueryPath) + "\\day8.txt")
	.Select(s => new
	{
		Original = s,
		Escaped = "\"" +
		s.Replace("\\", "\\\\")
		 .Replace("\"", "\\\"") + "\""
	})
.Dump("expanded")
.Sum(s => s.Escaped.Length - s.Original.Length)
.Dump("b"); // 2046