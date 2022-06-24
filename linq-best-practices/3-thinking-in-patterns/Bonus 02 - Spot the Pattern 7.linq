<Query Kind="Program" />

class Order
{
	public int Id { get; set; }
	public string CustomerName { get; set; }
	public string Status { get; set; }
	public OrderLine[] OrderLines { get; set; }
}

class OrderLine
{
	public string Product { get; set; }
	public int Quantity { get; set; }
}

List<Order> orders = new List<Order>()
{
	new Order { Id = 123, CustomerName = "Mark", Status = "Delivered", OrderLines = new OrderLine[] {} },
	new Order { Id = 456, CustomerName = "Steph", Status = "Refunded", OrderLines = new OrderLine[] {} },
	new Order { Id = 768, CustomerName = "Claire", Status = "Delivered", OrderLines = new OrderLine[] { new OrderLine() { Product = "Shoes", Quantity = 3} }},
	new Order { Id = 222, CustomerName = "Mark", Status = "Delivered", OrderLines = new OrderLine[] {} },
	new Order { Id = 333, CustomerName = "Steph", Status = "Awaiting Stock", OrderLines = new OrderLine[] {} },
};

void Main()
{
	Console.WriteLine("Nested foreach loops");
	
	foreach (var order in orders)
	{
		foreach (var orderLine in order.OrderLines)
		{
			Console.WriteLine("{0} Ordered {1} of {2}",
				order.CustomerName,
				orderLine.Quantity,
				orderLine.Product);
		}
	}
	
	Console.WriteLine("SelectMany");
	foreach (var orderLine in orders.SelectMany(o => o.OrderLines))
	{
		Console.WriteLine("Ordered {0} of {1}",
			orderLine.Quantity,
			orderLine.Product);
	}

	Console.WriteLine("SelectMany with 2 parameters");
	foreach (var orderLine in orders.SelectMany(o => o.OrderLines, 
				(o,l) => new { Order = o, Line = l}))
	{
		Console.WriteLine("{0} ordered {1} of {2}",
			orderLine.Order.CustomerName,
			orderLine.Line.Quantity,
			orderLine.Line.Product);
	}

}