using System.Collections.Generic;
using System.Linq;

namespace Checkout_Kata
{
	class Checkout : ICheckout
	{
		private readonly IEnumerable<ItemPrice> _prices;
		private readonly IEnumerable<IItemDiscount> _discounts;

		public Checkout(IEnumerable<ItemPrice> prices, IEnumerable<IItemDiscount> discounts)
		{
			_prices = prices;
			_discounts = discounts;
		}

		public int Total(string basket)
		{
			var items = basket.ToCharArray();
			return items.Sum(item => _prices.Single(p => p.ItemCode == item).Price);
		}

		public int Discount(string basket)
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