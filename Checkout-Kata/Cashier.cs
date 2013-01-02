using System.Collections.Generic;
using System.Linq;

namespace Checkout_Kata
{
	internal class Cashier
	{
		private readonly IEnumerable<ItemPrice> _prices;
		private readonly IEnumerable<IItemDiscount> _discounts;

		public Cashier(IEnumerable<ItemPrice> prices, IEnumerable<IItemDiscount> discounts)
		{
			_prices = prices;
			_discounts = discounts;
		}

		public int ScanBasket(string basket = "")
		{
			return Total(basket) - Discount(basket);
		}

		private int Total(string basket)
		{
			var items = basket.ToCharArray();
			return items.Sum(item => _prices.Single(p => p.ItemCode == item).Price);
		}

		private int Discount(string basket)
		{
			return _discounts.Sum(itemDiscount => CalculateItemDiscount(basket, itemDiscount));
		}

		private static int CalculateItemDiscount(string basket, IItemDiscount discount)
		{
			var itemCount = basket.Count(item => item == discount.ItemCode);
			return itemCount / discount.DiscountQuantity * discount.DiscountValue;
		}
	}
}