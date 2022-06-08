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
	new Order { Id = 123, CustomerName = "Mark", Status = "Delivered",
		OrderLines = new OrderLine[] {
			new OrderLine() { Product = "Headphones", Quantity = 2},
			new OrderLine() { Product = "Batteries", Quantity = 3} } },
	new Order { Id = 456, CustomerName = "Steph", Status = "Refunded",
		OrderLines = new OrderLine[] {
			new OrderLine() { Product = "Paint Brush", Quantity = 1 },
			new OrderLine() { Product = "Gloves", Quantity = 2}
		} },
	new Order { Id = 768, CustomerName = "Claire", Status = "Delivered", 
		OrderLines = new OrderLine[] { 
			new OrderLine() { Product = "Shoes", Quantity = 3} }},
	new Order { Id = 222, CustomerName = "Mark", Status = "Delivered",
		OrderLines = new OrderLine[] {
			new OrderLine() { Product = "Football", Quantity = 1 }
			} },
};

void Main()
{
	foreach (var orderLine in orders.SelectMany(o => o.OrderLines,
	(o, l) => new { Order = o, Line = l }))
	{
		Console.WriteLine("{0} Ordered {1} of {2}",
			orderLine.Order.CustomerName,
			orderLine.Line.Quantity,
			orderLine.Line.Product);
	}
}











