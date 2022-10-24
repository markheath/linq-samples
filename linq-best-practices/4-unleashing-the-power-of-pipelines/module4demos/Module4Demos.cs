using System.Text.RegularExpressions;

class Module4Demos
{
    // clip 9
    void AlbumDurationLINQChallenge()
    {
        var duration = "2:54,3:48,4:51,3:32,6:15,4:08,5:17,3:13,4:16,3:55,4:53,5:35,4:24"
            .Split(',')
            .Select(t => TimeSpan.Parse("0:" + t))
            .Aggregate((t1,t2) => t1 + t2);
        Console.WriteLine($"Duration {duration}");
    }

    // clip 10 
    void RangeExpansionLINQChallenge()
    {
        // Expand the range 
        // e.g. "2,3-5,7" should expand to 2,3,4,5,7
        // "6,1-3,2-4" should expand to 1,2,3,4,6
        "6,1-3,2-4"
            .Split(',')
            .Select(x => x.Split('-'))
            .Select(p => new { First = int.Parse(p[0]), Last = int.Parse(p.Last()) })
            .SelectMany(r => Enumerable.Range(r.First, r.Last - r.First + 1))
            .OrderBy(r => r)
            .Distinct()
            .Dump();
    }

    void RangeExpansionLINQChallengeExpanded()
    {
        // Expand the range 
        // e.g. "2,3-5,7" should expand to 2,3,4,5,7
        // "6,1-3,2-4" should expand to 1,2,3,4,6
        "6,1-3,2-4"
            .Split(',')
            .Select(x => x.Split('-'))
            .Select(p => new { First = int.Parse(p[0]), Last = int.Parse(p.Last()) })
            .SelectMany(r => Enumerable.Range(r.First, r.Last - r.First + 1))
            .OrderBy(r => r)
            .Distinct()
            .Dump();
    }

    // clip 11
    void FindInFiles()
    {
        var myDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var diagsFolder = Path.Combine(myDocs, "SkypeVoiceChanger", "diags");
        var fileType = "*.csv";
        var searchTerm = "User Submitted";
        Directory.EnumerateFiles(diagsFolder, fileType)
            .SelectMany(file => File.ReadAllLines(file)
                .Select((line, index) => new
                {
                    File = file,
                    Text = line,
                    LineNumber = index + 1
                })
            )
            .Where(line => Regex.IsMatch(line.Text, searchTerm))
            .Take(10)
            .Dump();
    }

    // clip 12
    void ParsingLogFiles()
    {
        var myDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var diagsFolder = Path.Combine(myDocs, "SkypeVoiceChanger", "diags");
        var fileType = "*.csv";
        Directory.EnumerateFiles(diagsFolder, fileType)
            .SelectMany(file => File.ReadAllLines(file)
                    .Skip(1)
                    .Select(line => line.Split(','))
                    .Where(parts => parts.Length > 8))
            .Where(parts => Regex.IsMatch(parts[8], "Checking license for"))
            .Select(parts => new
            {
                Date = DateTime.Parse(parts[0]),
                License = Regex.Match(parts[8], @"\d+").Value,
                FirstTime = Regex.Match(parts[9], @"True|False").Value,
            })
            .Where(x => x.License.Length >= 6)
            .Select(e => e.License)
            .Distinct()
            .Dump();
    }

    enum Example
    {
        Apples = 1,
        Bananas = 2,
        Oranges = 3,
        Pears = 3
    }

    enum Example2
    {
        Apples = 1,
        Bananas = 2,
        Oranges = 3,
    }

    // clip 13
    void EnumDuplicateChecking()
    {
        Enum.GetNames(typeof(Example))
            .Select(n => new { Name = n, Number = (int)Enum.Parse<Example>(n) })
            .GroupBy(n => n.Number)
            .Where(g => g.Count() > 1)
            .Dump("Duplicates");
            
        Enum.GetNames(typeof(Example))
            .Except(Enum.GetNames(typeof(Example2)))
            .Dump("missing");
            
    }
}