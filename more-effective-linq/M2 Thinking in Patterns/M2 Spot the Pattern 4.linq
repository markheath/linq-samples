<Query Kind="Program" />

class Order
{
	public int Id { get; set; }
	public decimal Amount { get; set; }
	public string CustomerName { get; set; }
	public string Status { get; set; }
}

List<Order> ordersDb = new List<Order>()
{
	new Order { Id = 123, Amount = 29.95m, CustomerName = "Mark", Status = "Delivered" },
	new Order { Id = 456, Amount = 45.00m, CustomerName = "Steph", Status = "Refunded" },
	new Order { Id = 768, Amount = 32.50m, CustomerName = "Claire", Status = "Delivered" },
};

Order GetOrderById(int orderNumber)
{
	return ordersDb.Single(o => o.Id == orderNumber);
}

void Main()
{
	var orderIds = new[] { 123, 456, 768 };
	GetListOfOrders(orderIds).Dump();
}

List<Order> GetListOfOrders(IEnumerable<int> orderIds)
{
	var orders = new List<Order>();
	foreach (var id in orderIds)
	{
		var order = GetOrderById(id);
		orders.Add(order);
	}
	return orders;
}

List<Order> GetListOfOrdersLinq(IEnumerable<int> orderIds)
{
	var orders = orderIds.Select(id => GetOrderById(id));
	return orders.ToList();
}

Dictionary<int, Order> CreateOrderDictionary(IEnumerable<int> orderIds)
{
	var orders = orderIds.Select(id => GetOrderById(id));
	return orders.ToDictionary(o => o.Id);
}