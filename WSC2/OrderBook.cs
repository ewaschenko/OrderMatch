namespace WS
{
	public class OrderBook
	{
		Dictionary<Symbol, List<Order>> buyOrders;
		Dictionary<Symbol, List<Order>> sellOrders;

		public OrderBook()
		{
			buyOrders = new Dictionary<Symbol, List<Order>>();
			sellOrders = new Dictionary<Symbol, List<Order>>();
		}

		public void AddOrder(Order order)
		{
			switch (order.type)
			{
				case OrderType.BUY:
					Match(buyOrders, sellOrders, order);
					break;
				case OrderType.SELL:
					Match(sellOrders, buyOrders, order);
					break;
				default:
					throw new Exception($"Invalid OrderType {order.type}");
			}
		}

		public void Match(Dictionary<Symbol, List<Order>> sameOrders, Dictionary<Symbol, List<Order>> oppOrders, Order order)
		{
			bool addToList = true;
			List<Order> orders;
			if (oppOrders.TryGetValue(order.symbol, out orders))
			{
				foreach (Order element in orders.ToList())
				{
					if (element.quantity == order.quantity && (order.type == OrderType.BUY ? order.price >= element.price : order.price <= element.price))
					{
						Print(order, element);
						orders.Remove(element);
						addToList = false;
						break;
					}
				} 

				// Added after interview, if incoming order is not matched, then add to same book
				if(addToList)
				{
					AddToSameBook(sameOrders, order);
				}
			}
			else
			{
				AddToSameBook(sameOrders, order);
			}
		}

		private void AddToSameBook(Dictionary<Symbol, List<Order>> sameOrders, Order order)
		{
			List<Order> orders;
			if (sameOrders.TryGetValue(order.symbol, out orders))
			{
				orders.Add(order);

				if (order.type == OrderType.BUY)
				{
					orders = orders.OrderByDescending(o => o.price).ThenBy(o => o.timeOrderPlaced).ToList();
				}
				else
				{
					orders = orders.OrderBy(o => o.price).ThenBy(o => o.timeOrderPlaced).ToList();
				}
			}
			else
			{
				orders = new List<Order>();
				orders.Add(order);
				sameOrders.Add(order.symbol, orders);
			}
		}

		private void Print(Order source, Order match)
		{
			Console.WriteLine($"Match Found: Source Order: {source} Match Order: {match}");
		}
	}
}
