<Query Kind="Program">
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{
	"Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988"
	.Split(';')
	.Select(n => n.Split(','))
	.Select(n => new { Name = n[0].Trim(), DateOfBirth = ParseDob(n[1])})
	.OrderByDescending(n => n.DateOfBirth)
	.Select(n => new { Name = n.Name, Age = GetAge(n.DateOfBirth) })
	.Dump();
}

static DateTime ParseDob(string dob) => DateTime.ParseExact(dob.Trim(), "d/M/yyyy", CultureInfo.InvariantCulture);

static int GetAge(DateTime dateOfBirth)
{
	DateTime today = DateTime.Today;
	int age = today.Year - dateOfBirth.Year;
	if (dateOfBirth > today.AddYears(-age)) age--;
	return age;
}
