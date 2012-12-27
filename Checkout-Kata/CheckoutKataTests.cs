using System.Collections.Generic;
using NUnit.Framework;

namespace Checkout_Kata
{
	[TestFixture]
	public class CheckoutKataTests
	{
		private readonly Dictionary<char, int> _prices = new Dictionary<char, int>
		{
			{'a', 50},
			{'b', 30},
			{'c', 20},
			{'d', 15}
		};

		private readonly IEnumerable<ItemDiscount> _discounters = new[]
		{
			new ItemDiscount
				{
					ItemCode = 'a',
					DiscountQuantity = 3,
					DiscountValue = 20
				},
			new ItemDiscount
				{
					ItemCode = 'b',
					DiscountQuantity = 2,
					DiscountValue = 15
				}
		};

		[Test]
		public void Scan_no_items_returns_0()
		{
			var actual = new Cashier(_prices, _discounters).ScanBasket();
			Assert.That(actual, Is.EqualTo(0));
		}

		[Test]
		public void Scan_empty_string_returns_0()
		{
			var actual = new Cashier(_prices, _discounters).ScanBasket(string.Empty);
			Assert.That(actual, Is.EqualTo(0));
		}

		[Test]
		[TestCase("a", 50)]
		[TestCase("b", 30)]
		[TestCase("c", 20)]
		[TestCase("d", 15)]
		public void Scan_returns_expected_price_for_item(string items, int expected)
		{
			var actual = new Cashier(_prices, _discounters).ScanBasket(items);
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase("aa", 100)]
		[TestCase("ab", 80)]
		[TestCase("abc", 100)]
		[TestCase("aabc", 150)]
		public void Multiple_items_ineligible_for_discount_returns_expected_total(string items, int expected)
		{
			var actual = new Cashier(_prices, _discounters).ScanBasket(items);
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase("aaa", 130)]
		[TestCase("aaaaaa", 260)]
		[TestCase("bb", 45)]
		[TestCase("bbbb", 90)]
		public void Multiple_of_the_same_item_eligible_for_discount_returns_expected_total(string items, int expected)
		{
			var actual = new Cashier(_prices, _discounters).ScanBasket(items);
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase("aaab", 160)]
		[TestCase("abb", 95)]
		[TestCase("aaaaaabb", 305)]
		[TestCase("bbbbacd", 175)]
		public void Multiple_items_eligible_for_discount_returns_expected_total(string items, int expected)
		{
			var actual = new Cashier(_prices, _discounters).ScanBasket(items);
			Assert.That(actual, Is.EqualTo(expected));
		}
	}
}
