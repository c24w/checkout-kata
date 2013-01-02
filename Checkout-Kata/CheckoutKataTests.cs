using System.Collections.Generic;
using NUnit.Framework;

namespace Checkout_Kata
{
	[TestFixture]
	public class CheckoutKataTests
	{
		private readonly IEnumerable<ItemPrice> _prices = new[]
		{
			new ItemPrice{ItemCode = 'a', Price = 50},
			new ItemPrice{ItemCode = 'b', Price = 30},
			new ItemPrice{ItemCode = 'c', Price = 20},
			new ItemPrice{ItemCode = 'd', Price = 15}
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
		public void Scan_one_item_returns_expected_total(string items, int expected)
		{
			var actual = new Cashier(_prices, _discounters).ScanBasket(items);
			Assert.That(actual, Is.EqualTo(expected));
		}

		[TestCase("aa", 100)]
		[TestCase("ab", 80)]
		[TestCase("abc", 100)]
		[TestCase("aabc", 150)]
		public void Scan_multiple_items_ineligible_for_discount_returns_expected_total(string items, int expected)
		{
			var actual = new Cashier(_prices, _discounters).ScanBasket(items);
			Assert.That(actual, Is.EqualTo(expected));
		}

		[TestCase("aaa", 130)]
		[TestCase("aaab", 160)]
		[TestCase("aaaaaa", 260)]
		[TestCase("aaaaaabb", 305)]
		[TestCase("bb", 45)]
		[TestCase("abb", 95)]
		[TestCase("bbbb", 90)]
		[TestCase("bbbbacd", 175)]
		public void Scan_multiple_items_eligible_for_discount_returns_expected_total(string items, int expected)
		{
			var actual = new Cashier(_prices, _discounters).ScanBasket(items);
			Assert.That(actual, Is.EqualTo(expected));
		}
	}
}
