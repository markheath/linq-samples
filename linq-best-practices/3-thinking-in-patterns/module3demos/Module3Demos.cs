class Module3Demos
{
    // clip 2
    void MotorSportLinqChallengeStartingPoint()
    {
        // in a motor sport competition, a player's points total
        // for the season is the sum of all the points earned in
        // each race, but the three worst results are not counted
        // towards the total. Calculate the following player's score
        // based on the points earned in each round:
        var input = "10,5,0,8,10,1,4,0,10,1";
        Console.WriteLine(input);
    }

    // clip 2
    void DaysToChristmasExample()
    {
        var daysToChristmas = new DateTime(DateTime.Today.Year, 12, 25) - DateTime.Today;
        Console.WriteLine(daysToChristmas);
    }

    // clip 4
    void SpotThePattern1()
    {
        var customers = new[] {
            new { Name = "Annie", Email = "annie@example.com" },
            new { Name = "Ben", Email = "" },
            new { Name = "Lily", Email = "lily@example.com" },
            new { Name = "Joel", Email = "joel@example.com" },
            new { Name = "Sam", Email = "" },
        };

        // starting point
        foreach (var customer in customers)
        {
            if (!String.IsNullOrEmpty(customer.Email))
            {
                Console.WriteLine($"Sending email to {customer.Name}");
            }
        }

        // solution with Where
        foreach (var customer in customers.Where(c => !String.IsNullOrEmpty(c.Email)))
        {
            Console.WriteLine($"Sending email to {customer.Name}");
        }

        // solution with Query Expression syntax
        foreach (var customer in
            from c in customers 
            where !String.IsNullOrEmpty(c.Email) 
            select c)
        {
            Console.WriteLine($"Sending email to {customer.Name}");
        }
    }

    class Order
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }
    }


    void SpotThePattern2()
    {
        List<Order> orders = new List<Order>()
        {
            new Order { Id = 123, Amount = 29.95m, CustomerName = "Mark" },
            new Order { Id = 456, Amount = 45.00m, CustomerName = "Steph" },
            new Order { Id = 768, Amount = 32.50m, CustomerName = "Claire" },
        };

        // starting point
        void RefundOrderOriginal(int orderId)
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

        void RefundOrder(int orderId)
        {
            var orderToRefund = orders.First(o => o.Id == orderId);
	        Console.WriteLine($"Refunding {orderToRefund.Amount} to {orderToRefund.CustomerName}");
        }


    	RefundOrder(456);
        // RefundOrder(999); // will give us an InvalidOperationException

    }
    void SpotThePattern3()
    {
        List<Order> orders = new List<Order>()
        {
            new Order { Id = 123, Amount = 29.95m, CustomerName = "Mark", Status = "Delivered" },
            new Order { Id = 456, Amount = 45.00m, CustomerName = "Steph", Status = "Refunded" },
            new Order { Id = 768, Amount = 32.50m, CustomerName = "Claire", Status = "Delivered" },
        };

        // original without LINQ
        void CheckOrdersForRefundsOriginal()
        {
            bool anyRefunded = false;
            foreach (var order in orders)
            {
                if (order.Status == "Refunded")
                {
                    anyRefunded = true;
                    break;
                }
            }
            
            if (anyRefunded)
                Console.WriteLine("There are refunded orders");
            else
                Console.WriteLine("No refunds");
        }

        // original without LINQ
        void CheckOrdersAreDeliveredOriginal()
        {
            bool allDelivered = true;
            foreach (var order in orders)
            {
                if (order.Status != "Delivered")
                {
                    allDelivered = false;
                    break;
                }
            }

            if (allDelivered)
                Console.WriteLine("Everything was delivered");
            else
                Console.WriteLine("Not everything was delivered");
        }

        void CheckOrdersForRefunds()
        {
            bool anyRefunded = orders.Any(o => o.Status == "Refunded");
            
            if (anyRefunded)
                Console.WriteLine("There are refunded orders");
            else
                Console.WriteLine("No refunds");
        }

        void CheckOrdersAreDelivered()
        {
            bool allDelivered = orders.All(o => o.Status == "Delivered");

            if (allDelivered)
                Console.WriteLine("Everything was delivered");
            else
                Console.WriteLine("Not everything was delivered");
        }

        CheckOrdersForRefunds();
        CheckOrdersAreDelivered();

    }

    // clip 7
    void SpotThePattern4()
    {
        var paths = new[] { "c:\\windows\\notepad.exe", "c:\\windows\\regedit.exe", "c:\\windows\\explorer.exe" };
        GetListOfFileSizes(paths).Dump();
        // dictionary version:
        paths.Select(p => new FileInfo(p))
            .ToDictionary(p => p.Name, p => p.Length)
            .Dump();

        // original
        List<long> GetListOfFileSizesOriginal(IEnumerable<string> paths)
        {
            var fileSizes = new List<long>();
            foreach (var path in paths)
            {
                var length = new FileInfo(path).Length;
                fileSizes.Add(length);
            }
            return fileSizes;
        }
        
        List<long> GetListOfFileSizes(IEnumerable<string> paths)
        {
            return paths.Select(p => new FileInfo(p).Length).ToList();
        }
    }

    void SpotThePattern5()
    {
        List<Order> orders = new List<Order>()
        {
            new Order { Id = 123, Amount = 29.95m, CustomerName = "Mark", Status = "Delivered" },
            new Order { Id = 456, Amount = 45.00m, CustomerName = "Steph", Status = "Refunded" },
            new Order { Id = 768, Amount = 32.50m, CustomerName = "Claire", Status = "Delivered" },
        };

        // original
        int CountRefundedOrdersOriginal()
        {
            int refundedCount = 0;
            foreach (var order in orders)
            {
                if (order.Status == "Refunded")
                    refundedCount++;
            }
            return refundedCount;
        }

        // original
        decimal GetOrderTotalOriginal()
        {
            decimal total = 0;
            foreach (var order in orders)
            {
                total += order.Amount;
            }
            return total;
        }
        
        int CountRefundedOrders()
        {
            return orders.Count(o => o.Status == "Refunded");
        }

        decimal GetOrderTotal()
        {
            return orders.Sum(o => o.Amount);
        }

        var refundedOrders = CountRefundedOrders();
        Console.WriteLine($"Refunded Orders: {refundedOrders}");
        var orderTotal = GetOrderTotal();
        Console.WriteLine($"Order Total: {orderTotal}");

    }

    // clip 9
    void SpotThePattern6()
    {
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
            var dict = new Dictionary<string,List<Order>>();
            foreach (var order in orders)
            {
                if (!dict.ContainsKey(order.CustomerId))
                    dict[order.CustomerId] = new List<Order>();
                dict[order.CustomerId].Add(order);
            }
            return dict;
        }
        // original:
        // OrdersByCustomer().Dump();

        orders.GroupBy(o => o.CustomerId)
            .ToDictionary(g => g.Key, g => g.ToList())
            .Dump();

    }

    // clip 11
    void MotorSportScoresSolution()
    {
        "10,5,0,8,10,1,4,0,10,1"
            .Split(',')
            .Select(int.Parse)
            .OrderBy(n => n)
            .Skip(3)
            .Sum()
            .Dump();
    }

    void MotorSportScoresSolutionWithoutLINQ()
    {
        // without LINQ
        var scores = "10,5,0,8,10,1,4,0,10,1".Split(',');

        var scoresAsInts = new List<int>();
        foreach (var score in scores)
        {
            var intScore = int.Parse(score);
            scoresAsInts.Add(intScore);
        }

        scoresAsInts.Sort();

        var total = 0;
        for (int n = 3; n < scoresAsInts.Count; n++)
        {
            total += scoresAsInts[n];
        }

        total.Dump("Score without LINQ");    
    }
}

