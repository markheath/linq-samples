<Query Kind="Statements" />

var customers = new[] {
	new { Name = "Annie", Email = "annie@example.com" },
	new { Name = "Ben", Email = "" },
	new { Name = "Lily", Email = "lily@example.com" },
	new { Name = "Joel", Email = "joel@example.com" },
	new { Name = "Sam", Email = "" },
};

foreach (var customer in
	from c in customers 
	where !String.IsNullOrEmpty(c.Email) 
	select c)
{
	Console.WriteLine($"Sending email to {customer.Name}");
}