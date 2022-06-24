<Query Kind="Program" />

class Order
{
	public int Id { get; set; }
	public decimal Amount { get; set; }
	public string CustomerName { get; set; }
}

List<Order> orders = new List<Order>()
{
	new Order { Id = 123, Amount = 29.95m, CustomerName = "Mark" },
	new Order { Id = 456, Amount = 45.00m, CustomerName = "Steph" },
	new Order { Id = 768, Amount = 32.50m, CustomerName = "Claire" },
};


void RefundOrder(int orderId)
{
	Order orderToRefund = null;
	foreach (var order in orders)
	{
		if (order.Id == orderId)
		{
			orderToRefund = order;
			break;
		}
	}
	Console.WriteLine($"Refunding {orderToRefund.Amount} to {orderToRefund.CustomerName}");
}

void Main()
{
	RefundOrder(456);
}