using System.Collections.Generic;
using System.Linq;

namespace Checkout_Kata
{
	internal class Cashier
	{
		private readonly Dictionary<char, int> _prices;
		private readonly Dictionary<char, int> _discountQuantity = new Dictionary<char, int>
		{
			{'a',3},
			{'b',2}
		};
		private readonly Dictionary<char, int> _discountValue = new Dictionary<char, int>
		{
			{'a',20},
			{'b',15}
		};

		public Cashier(Dictionary<char, int> prices)
		{
			_prices = prices;
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
			var discount = 0;
			foreach (var item in _discountQuantity.Keys)
				discount += DiscountItem(basket, item);
			return discount;
		}

		private int DiscountItem(string basket, char discountItem)
		{
			var numberOfItem = basket.Count(item => item == discountItem);
			return numberOfItem / _discountQuantity[discountItem] * _discountValue[discountItem];
		}
	}
}