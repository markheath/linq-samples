<Query Kind="Statements" />

var customers = new[] {
	new { Name = "Annie", Email = "annie@test.com" },
	new { Name = "Ben", Email = "" },
	new { Name = "Lily", Email = "lily@test.com" },
	new { Name = "Joel", Email = "joel@test.com" },
	new { Name = "Sam", Email = "" },
};

foreach (var customer in customers.Where(c => !String.IsNullOrEmpty(c.Email)))
{
	Console.WriteLine("Sending email to {0}", customer.Name);
}