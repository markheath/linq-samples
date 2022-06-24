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
	orders.Max(o => o.Amount).Dump("Max order");
	
	decimal maxAmount = 0M;
	foreach (var order in orders)
	{
		if (order.Amount > maxAmount)
			maxAmount = order.Amount;
	}
}

int CountRefundedOrders()
{
	int refundedCount = 0;
	foreach (var order in orders)
	{
		if (order.Status == "Refunded")
			refundedCount++;
	}
	return refundedCount;
}

decimal GetOrderTotal()
{
	decimal total = 0;
	foreach (var order in orders)
	{
		total += order.Amount;
	}
	return total;
}

int CountRefundedOrdersLinq()
{
	return orders.Count(o => o.Status == "Refunded");
}

decimal GetOrderTotalLinq()
{
	return orders.Sum(o => o.Amount);
}
