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

int CountRefundedOrders()
{
	return orders.Count(o => o.Status == "Refunded");
}

decimal GetOrderTotal()
{
	return orders.Sum(o => o.Amount);
}

void Main()
{
	CountRefundedOrders().Dump("Refunded Orders");
	GetOrderTotal().Dump("Order Total");
}