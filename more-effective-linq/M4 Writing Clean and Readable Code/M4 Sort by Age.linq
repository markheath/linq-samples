<Query Kind="Expression">
  <Namespace>System.Globalization</Namespace>
</Query>

"Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988"
.Split(';')
.Select(s => s.Split(','))
.Select(s => new { Name = s[0].Trim(), 
	Dob = DateTime.ParseExact(s[1].Trim(), "d/M/yyyy", 
	CultureInfo.InvariantCulture) })
//.Select(s => new { Name = s.Name, Dob = s.Dob, Age = (int)((DateTime.Today - s.Dob).TotalDays / 365.25) })
.OrderByDescending(s=> s.Dob)
.Select(p =>
{
	var today = DateTime.Today;
	int age = today.Year - p.Dob.Year;
	if (p.Dob > today.AddYears(-age)) age--;
	return new { p.Name, p.Dob, Age = age };
})
.Select(s => String.Format("{0}: {1}", s.Name, s.Age))