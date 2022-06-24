<Query Kind="Program" />

void Main()
{
	
}

IEnumerable<Order> GetOrdersAwaitingDelivery1()
{
	return orders.Where(o => o.Status == "OrderPlaced");
}

Order[] GetOrdersAwaitingDelivery2()
{
	return orders.Where(o => o.Status == "OrderPlaced").ToArray();
}

List<Order> GetOrdersAwaitingDelivery3()
{
	return orders.Where(o => o.Status == "OrderPlaced").ToList();
}

List<Order> GetOrdersAwaitingDelivery4()
{
	return orders.Where(o => o.Status == "OrderPlaced").ToList();
}

IReadOnlyCollection<Order> GetOrdersAwaitingDelivery5()
{
	return orders.Where(o => o.Status == "OrderPlaced").ToList();
}

IQueryable<Order> GetOrdersAwaitingDelivery6()
{
	return orders.Where(o => o.Status == "OrderPlaced").ToList().AsQueryable();
}

class Order { public string Status { get; set; } }

List<Order> orders; // a list here, but could