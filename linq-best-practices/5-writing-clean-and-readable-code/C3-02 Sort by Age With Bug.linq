<Query Kind="Expression">
  <Namespace>System.Globalization</Namespace>
</Query>

// The following list of football players contains a name followed by a date of birth in day/month/year format.
// Sort them into a sequence ordered from youngest to oldest, and display the player's name and current age
"Fraser Forster, 17/03/1988; Kyle Walker-Peters, 13/04/1997; Jan Bednarek, 12/04/1996; James Ward-Prowse, 01/11/1994; Shane Long, 22/01/1987; Mohamed Elyounoussi, 04/08/1994"
.Split(';')
.Select(s => s.Split(','))
.Select(s => new { Name = s[0].Trim(), 
	DateOfBirth = DateTime.ParseExact(s[1].Trim(), "d/M/yyyy", 
	CultureInfo.InvariantCulture) })
.OrderByDescending(s=> s.DateOfBirth)
.Select(n => new { Name = n.Name, Age = DateTime.Today.Year - n.DateOfBirth.Year })
