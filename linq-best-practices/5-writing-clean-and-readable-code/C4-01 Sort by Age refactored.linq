<Query Kind="Program">
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
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
}

static DateTime ParseDateOfBirth(string dateOfBirth) => 
	DateTime.ParseExact(dateOfBirth.Trim(), "d/M/yyyy", CultureInfo.InvariantCulture);

static int GetAge(DateTime dateOfBirth)
{
	DateTime today = DateTime.Today;
	int age = today.Year - dateOfBirth.Year;
	if (dateOfBirth > today.AddYears(-age)) age--;
	return age;
}
