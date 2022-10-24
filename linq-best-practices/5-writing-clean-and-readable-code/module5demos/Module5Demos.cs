using System.Globalization;

public class Module5Demos
{
    // clip 3
    public void SortByAgeLinqChallenge()
    {
        // The following list of football players contains a name followed by a date of birth in day/month/year format.
        // Sort them into a sequence ordered from youngest to oldest, and display the player's name and current age
        "Fraser Forster, 17/03/1988; Kyle Walker-Peters, 13/04/1997; Jan Bednarek, 12/04/1996; James Ward-Prowse, 01/11/1994; Shane Long, 22/01/1987; Mohamed Elyounoussi, 04/08/1994"
        .Split(';')
        .Select(s => s.Split(','))
        .Select(s => new { Name = s[0].Trim(), 
            DateOfBirth = DateTime.ParseExact(s[1].Trim(), "d/M/yyyy", 
            CultureInfo.InvariantCulture) })
        .OrderByDescending(s=> s.DateOfBirth)
        .Select(p =>
        {
            var today = DateTime.Today;
            int age = today.Year - p.DateOfBirth.Year;
            if (p.DateOfBirth > today.AddYears(-age)) age--;
            return new { p.Name, p.DateOfBirth, Age = age };
        })
        .Select(s => $"{s.Name}: {s.Age}")
        .Dump();
    }

    // clip 4
    public void SortByAgeLinqChallengeRefactored()
    {
        // The following list of football players contains a name followed by a date of birth in day/month/year format.
        // Sort them into a sequence ordered from youngest to oldest, and display the player's name and current age
        "Fraser Forster, 17/03/1988; Kyle Walker-Peters, 13/04/1997; Jan Bednarek, 12/04/1996; James Ward-Prowse, 01/11/1994; Shane Long, 22/01/1987; Mohamed Elyounoussi, 04/08/1994"
            .Split(';')
            .Select(n => n.Split(','))
            .Select(n => new { Name = n[0].Trim(), DateOfBirth = ParseDateOfBirth(n[1]) })
            .OrderByDescending(n => n.DateOfBirth)
            .Select(n => new { Name = n.Name, Age = GetAge(n.DateOfBirth) })
            .Dump();

        static DateTime ParseDateOfBirth(string dateOfBirth) => 
            DateTime.ParseExact(dateOfBirth.Trim(), "d/M/yyyy", CultureInfo.InvariantCulture);

        static int GetAge(DateTime dateOfBirth)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dateOfBirth.Year;
            if (dateOfBirth > today.AddYears(-age)) age--;
            return age;
        }
    }

    // clip 5
    public void BishopMovesSolution1()
    {
        // we start with a Bishop on c6
        // what positions can it reach in one move?
        // output should include b5, a4, b7, a8
        Enumerable.Range('a', 8)
            .SelectMany(x => Enumerable.Range('1', 8),
                        (f, r) => new { File = (char)f, Rank = (char)r })
            .Where(x => Math.Abs(x.File - 'c') == Math.Abs(x.Rank - '6'))
            .Where(x => x.File != 'c')
            .Select(x => $"{x.File}{x.Rank}")
            .Dump();
    }

    public void BishopMovesSolution2()
    {
        // we start with a Bishop on c6
        // what positions can it reach in one move?
        // output should include b5, a4, b7, a8
        Enumerable.Range('a', 8)
            .SelectMany(x => Enumerable.Range('1', 8), 
                (f, r) => new { File = (char)f, Rank = (char)r })
            .Select(x => new { x.File, x.Rank, dx = Math.Abs(x.File - 'c'), dy = Math.Abs(x.Rank - '6') })
            .Where(x => x.dx == x.dy && x.dx != 0)
            .Select(x => $"{x.File}{x.Rank}")
            .Dump();
    }

    // clip 6
    public void BishopMovesRefactoredDynamic()
    {
        // we start with a Bishop on c6
        // what positions can it reach in one move?
        // output should include b5, a4, b7, a8
        var chessBoardPositions = Enumerable.Range('a', 8)
            .SelectMany(x => Enumerable.Range('1', 8), 
                (f, r) => new { File = (char)f, Rank = (char)r });
        
        var validMoves = chessBoardPositions
            .Where(x => BishopCanMoveTo(new { File = 'c', Rank = '6' }, x))
            .Select(x => $"{x.File}{x.Rank}");
            
        validMoves.Dump();

        bool BishopCanMoveTo(dynamic startingPosition, dynamic targetLocation)
        {
            var dx = Math.Abs(startingPosition.File - targetLocation.File);
            var dy = Math.Abs(startingPosition.Rank - targetLocation.Rank);
            return dx == dy && dx != 0;
        }
    }

    public void BishopMovesRefactoredString()
    {
        GetBoardPositions()
            .Where(p => BishopCanMoveTo(p,"c6"))
            .Dump();

        static IEnumerable<string> GetBoardPositions()
        {
            return Enumerable.Range('a', 8).SelectMany(
                x => Enumerable.Range('1', 8), (f, r) => 
                    $"{(char)f}{(char)r}");
        }

        static bool BishopCanMoveTo(string startPos, string targetPos)
        {
            var dx = Math.Abs(startPos[0] - targetPos[0]);
            var dy = Math.Abs(startPos[1] - targetPos[1]);
            return dx == dy && dx != 0;
        }
    }

    // clip 7
    public void BishopMovesQuerySyntax()
    {
        var moves = from row in Enumerable.Range('a', 8)
                    from col in Enumerable.Range('1', 8)
                    let dx = Math.Abs(row - 'c')
                    let dy = Math.Abs(col - '6')
                    where dx == dy
                    where dx != 0
                    select $"{(char)row}{(char)col}";
        moves.Dump();
    } 

    // clip 8
    public void LongestBookVariousSolutions()
    {
        var books = new[] {
            new { Author = "Robert Martin", Title = "Clean Code", Pages = 464 },
            new { Author = "Enrico Buonanno", Title = "Functional Programming in C#" , Pages = 425 },
            new { Author = "Martin Fowler", Title = "Patterns of Enterprise Application Architecture", Pages = 533 },
            new { Author = "Bill Wagner", Title = "Effective C#", Pages = 328 },
        };

        books.Max(b => b.Pages).Dump("Max");

        books.First(b => b.Pages == books.Max(x => x.Pages)).Dump("Bad!");

        var mostPages = books.Max(x => x.Pages);
        books.First(b => b.Pages == mostPages).Dump("Better!");

        books.OrderByDescending(b => b.Pages).First().Dump("Hmmm!");

        books.Aggregate((agg, next) => next.Pages > agg.Pages ? next : agg).Dump("Good");

        books.MaxBy(b => b.Pages).Dump("Best");
    }
}