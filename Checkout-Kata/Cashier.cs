using System.Collections.Generic;
using System.Linq;

namespace Checkout_Kata
{
	internal class Cashier
	{
		private readonly Dictionary<char, int> _itemPrices;
		private readonly IEnumerable<IItemDiscount> _itemDiscounts;	

		public Cashier(Dictionary<char, int> itemPrices, IEnumerable<IItemDiscount> itemDiscounts)
		{
			_itemPrices = itemPrices;
			_itemDiscounts = itemDiscounts;
		}

		public int ScanBasket(string basket = "")
		{
			return Total(basket) - Discount(basket);
		}

		private int Total(string basket)
		{
			var items = basket.ToCharArray();
			return items.Sum(item => _itemPrices[item]);
		}

		private int Discount(string basket)
		{
			return _itemDiscounts.Sum(itemDiscount => CalculateItemDiscount(basket, itemDiscount));
		}

		private static int CalculateItemDiscount(string basket, IItemDiscount discount)
		{
			var itemCount = basket.Count(item => item == discount.ItemCode);
			return itemCount / discount.DiscountQuantity * discount.DiscountValue;
		}
	}
}