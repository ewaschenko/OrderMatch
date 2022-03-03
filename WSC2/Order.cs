namespace WS
{
	public class Order
	{
		public Symbol symbol;
		public double price;
		public int quantity;
		public DateTime timeOrderPlaced;
		public OrderType type;

		public Order(Symbol symbol, OrderType type, double price, int quantity)
		{
			this.symbol = symbol;
			this.price = price;
			this.quantity = quantity;
			this.timeOrderPlaced = DateTime.Now;
			this.type = type;
		}

		public override string ToString()
		{
			return $"Order [symbol: {symbol} | type: {type} | price: {price} | quantity: {quantity}]";
		}
	}
}
