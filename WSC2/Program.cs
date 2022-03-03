using WS;

List<Order> orders = new List<Order>();
orders.Add(new Order(Symbol.WS, OrderType.BUY, 100.00, 50));
orders.Add(new Order(Symbol.WS, OrderType.BUY, 150.00, 45));
orders.Add(new Order(Symbol.WS, OrderType.SELL, 100.00, 45));
orders.Add(new Order(Symbol.INF, OrderType.SELL, 100.00, 25));
orders.Add(new Order(Symbol.INF, OrderType.BUY, 100.00, 25));
orders.Add(new Order(Symbol.BW, OrderType.SELL, 100.00, 25));
orders.Add(new Order(Symbol.BW, OrderType.BUY, 100.00, 25));

OrderBook orderBook = new OrderBook();

foreach (Order element in orders)
{
	orderBook.AddOrder(element);
}