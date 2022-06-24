<Query Kind="Program" />

class Order
{
	public int Id { get; set; }
	public decimal Amount { get; set; }
	public string CustomerId { get; set; }
	public string Status { get; set; }
}

List<Order> orders = new List<Order>()
{
	new Order { Id = 123, Amount = 29.95m, CustomerId = "Mark", Status = "Delivered" },
	new Order { Id = 456, Amount = 45.00m, CustomerId = "Steph", Status = "Refunded" },
	new Order { Id = 768, Amount = 32.50m, CustomerId = "Claire", Status = "Delivered" },
	new Order { Id = 222, Amount = 300.00m, CustomerId = "Mark", Status = "Delivered" },
	new Order { Id = 333, Amount = 465.00m, CustomerId = "Steph", Status = "Awaiting Stock" },
};

Dictionary<string, List<Order>> OrdersByCustomer()
{
	var dict = new Dictionary<string, List<Order>>();
	foreach (var order in orders)
	{
		if (!dict.ContainsKey(order.CustomerId))
			dict[order.CustomerId] = new List<Order>();
		dict[order.CustomerId].Add(order);
	}
	return dict;
}

void Main()
{
	//OrdersByCustomer().Dump();
	orders.GroupBy(o => o.CustomerId)
		.ToDictionary(g => g.Key, g => g.ToList())
		.Dump();
}



