<Query Kind="Program">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

void Main()
{
    File.ReadAllText(
	Path.GetDirectoryName(Util.CurrentQueryPath) +
	"\\day3.txt")
		.Batch(2)
		.Scan(new { Santa = new Pos(0, 0), RoboSanta = new Pos(0, 0) }, (state, c) =>
              new { Santa = Move(c.First(), state.Santa),
                  RoboSanta = Move(c.Last(), state.RoboSanta)
              })
        .SelectMany(p => new[] { p.Santa, p.RoboSanta } )
        .Select(p => String.Format("{0},{1}", p.X, p.Y))
        .GroupBy(p => p)
        //.Count(g => g.Count() > 1)
        .Count()
        .Dump();   
}

public class Pos
{
    public Pos(int x, int y)
    {
        X = x; Y = y;
    }
    public int X { get; } 
    public int Y { get; } 
}

Pos Move(char direction, Pos startingPoint)
{
    return 
        direction == '>' ? new Pos(startingPoint.X + 1, startingPoint.Y) :
        direction == '^' ? new Pos(startingPoint.X, startingPoint.Y + 1) :
        direction == '<' ? new Pos(startingPoint.X - 1, startingPoint.Y) :
						   new Pos(startingPoint.X, startingPoint.Y - 1);
}