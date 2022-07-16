<Query Kind="Statements" />

var customers = new[] { 
	new { Name = "Annie", Email = "annie@example.com" },
	new { Name = "Ben", Email = "" },
	new { Name = "Lily", Email = "lily@example.com" },
	new { Name = "Joel", Email = "joel@example.com" },
	new { Name = "Sam", Email = "" },
};

// what LINQ method can help here?
foreach (var customer in customers)
{
	if (!String.IsNullOrEmpty(customer.Email))
	{
		Console.WriteLine($"Sending email to {customer.Name}");
	}
}

