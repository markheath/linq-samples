<Query Kind="Program">
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{
	"Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988"
	.Split(';')
	.Select(s => s.Split(','))
	.Select(s => new { Name = s[0].Trim(), Dob = DateTime.ParseExact(s[1].Trim(), "d/M/yyyy", CultureInfo.InvariantCulture) })
	.OrderByDescending(s => s.Dob)
	.Select(s => new { s.Name, Age = GetAge(s.Dob) })
	.Select(s => String.Format("{0}: {1}", s.Name, s.Age))
	.Dump("E1");

	"Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988"
	.Split(';')
	.Select(s => s.Split(','))
	.Select(s => new { Name = s[0].Trim(), Dob = ParseDob2(s[1]) })
	.OrderByDescending(s => s.Dob)
	.Select(s => new { s.Name, Age = GetAge(s.Dob) })
	.Select(s => String.Format("{0}: {1}", s.Name, s.Age))
	.Dump("Ex2");

	"Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988"
	.Split(';')
	.Select(s => s.Split(','))
	.Select(s => new { Name = s[0].Trim(), Dob = ParseDob2(s[1]) })
	.OrderByDescending(s => s.Dob)
	.Select(s => String.Format("{0}: {1}", s.Name, GetAge(s.Dob)))
	.Dump("Ex3");


	var peopleSortedByDob = "Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988"
		.Split(';')
		.Select(s => s.Split(','))
		.Select(s => new { Name = s[0].Trim(), Dob = ParseDob2(s[1]) })
		.OrderByDescending(s => s.Dob);

	peopleSortedByDob.Select(s => new { s.Name, Age = GetAge(s.Dob) })
		.Select(s => String.Format("{0}: {1}", s.Name, s.Age))
		.Dump("Ex2");

	Func<string, DateTime> pd = date => DateTime.ParseExact(date.Trim(), "d/M/yyyy", CultureInfo.InvariantCulture);
}

static int GetAge(DateTime dateOfBirth)
{
	var today = DateTime.Today;
	int age = today.Year - dateOfBirth.Year;
	if (dateOfBirth > today.AddYears(-age)) age--;
	return age;
}

static DateTime ParseDob(string date)
{
	return DateTime.ParseExact(date.Trim(), "d/M/yyyy", CultureInfo.InvariantCulture);
}

static DateTime ParseDob2(string date) => DateTime.ParseExact(date.Trim(), "d/M/yyyy", CultureInfo.InvariantCulture);
