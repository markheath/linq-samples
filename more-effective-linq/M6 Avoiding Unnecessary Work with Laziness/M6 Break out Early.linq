<Query Kind="Program" />

class Order
{
	public int Id { get; set; }
	public decimal Amount { get; set; }
	public string CustomerName { get; set; }
	public string Status { get; set; }
}

List<Order> orders = new List<Order>()
{
	new Order { Id = 123, Amount = 29.95m, CustomerName = "Mark", Status = "Delivered" },
	new Order { Id = 456, Amount = 45.00m, CustomerName = "Steph", Status = "Refunded" },
	new Order { Id = 768, Amount = 32.50m, CustomerName = "Claire", Status = "Delivered" },
};

void CheckOrdersForRefunds()
{
	bool anyRefunded = orders.Any(o => o.Status == "Refunded");
		
	if (anyRefunded)
		Console.WriteLine("There are refunded orders");
	else
		Console.WriteLine("No refunds");
}



void Main()
{
	CheckOrdersForRefunds();
}

void CheckOrdersForRefundsLinq()
{
	bool anyRefunded = orders.Any(o => o.Status == "Refunded");

	if (anyRefunded)
		Console.WriteLine("There are refunded orders");
	else
		Console.WriteLine("No refunds");
}

void CheckOrdersAreDeliveredLinq()
{
	bool allDelivered = orders.All(o => o.Status == "Delivered");

	if (allDelivered)
		Console.WriteLine("Everything was delivered");
	else
		Console.WriteLine("Not everything was delivered");
}