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

void Main()
{
	var anyRefunded1 = orders.Any(o => o.Status == "Refunded")
	

	bool anyRefunded2 = false;
	foreach (var order in orders)
	{
		if (order.Status == "Refunded")
		{
			anyRefunded2 = true;
			break;
		}
	}
	var anyRefunded3 = orders.Where(o => o.Status == "Refunded").Count() > 0;

	var count = 0;
	foreach (var order in orders)
	{
		if (order.Status == "Refunded")
		{
			count++;
		}
	}
	var anyRefunded4 = count > 0;

}

