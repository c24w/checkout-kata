﻿using System.Collections.Generic;
using System.Linq;
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

		[Test]
		public void Scan_no_items_returns_0()
		{
			var actual = new Cashier(_prices).Scan();
			Assert.That(actual, Is.EqualTo(0));
		}

		[Test]
		public void Scan_empty_string_returns_0()
		{
			var actual = new Cashier(_prices).ScanBasket(string.Empty);
			Assert.That(actual, Is.EqualTo(0));
		}

		[Test]
		[TestCase("a", 50)]
		[TestCase("b", 30)]
		[TestCase("c", 20)]
		[TestCase("d", 15)]
		public void Scan_returns_expected_price_for_item(string items, int expected)
		{
			var actual = new Cashier(_prices).ScanBasket(items);
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase("aa", 100)]
		[TestCase("ab", 80)]
		[TestCase("abc", 100)]
		[TestCase("aabc", 150)]
		public void Multiple_items_ineligible_for_discount_returns_expected_total(string items, int expected)
		{
			var actual = new Cashier(_prices).ScanBasket(items);
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase("aaa", 130)]
		[TestCase("aaaaaa", 260)]
		[TestCase("bb", 45)]
		[TestCase("bbbb", 90)]
		public void Multiple_of_the_same_item_eligible_for_discount_returns_expected_total(string items, int expected)
		{
			var actual = new Cashier(_prices).ScanBasket(items);
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase("aaab", 160)]
		[TestCase("abb", 95)]
		[TestCase("aaaaaabb", 305)]
		[TestCase("bbbbac", 160)]
		public void Multiple_items_eligible_for_discount_returns_expected_total(string items, int expected)
		{
			var actual = new Cashier(_prices).ScanBasket(items);
			Assert.That(actual, Is.EqualTo(expected));
		}
	}

	class Cashier
	{
		private readonly Dictionary<char, int> _prices;

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
			discount += DiscountItem(basket, 'a', 3, 20);
			discount += DiscountItem(basket, 'b', 2, 15);
			return discount;
		}

		private static int DiscountItem(string basket, char discountItem, int discountQuantity, int discountAmount)
		{
			var numberOfItems = basket.Count(item => item == discountItem);
			return numberOfItems / discountQuantity * discountAmount;
		}

	}
}
