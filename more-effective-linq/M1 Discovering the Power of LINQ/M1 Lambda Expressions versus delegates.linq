<Query Kind="Program" />

void Main()
{
	var customers = new[]  { new Customer { Name  = "Mark", Email="" } };
	customers.Where (c => c.Email != null).Dump();
	
	customers.Where(delegate(Customer c) { return c.Email != null; }).Dump(); 
	
	
	
}

class Customer { public string Name { get; set;} public string Email { get;set;} }