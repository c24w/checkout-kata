using System.Collections.Generic;
using System.Linq;

namespace Checkout_Kata
{
	internal class Cashier
	{
		private readonly Dictionary<char, int> _prices;
		private readonly IEnumerable<ItemDiscounter> _discounters;	

		public Cashier(Dictionary<char, int> prices, IEnumerable<ItemDiscounter> discounters)
		{
			_prices = prices;
			_discounters = discounters;
		}

		public int Scan()
		{
			return 0;
		}

		public int ScanBasket(string basket)
		{
			return Total(basket) - Discount(basket);
		}

		private int Total(string basket)
		{
			var items = basket.ToCharArray();
			return items.Sum(item => _prices[item]);
		}

		private int Discount(string basket)
		{
			return _discounters.Sum(discounter => DiscountItem(basket, discounter));
		}

		private int DiscountItem(string basket, ItemDiscounter discounter)
		{
			var itemCount = basket.Count(item => item == discounter.ItemCode);
			return itemCount / discounter.DiscountQuantity * discounter.DiscountValue;
		}
	}
}