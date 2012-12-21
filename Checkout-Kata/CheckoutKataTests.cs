using System.Collections.Generic;
using NUnit.Framework;

namespace Checkout_Kata
{
	[TestFixture]
	public class CheckoutKataTests
	{
		[Test]
		public void Scan_no_items_returns_0()
		{
			var actual = new Scanner().Scan();
			Assert.That(actual, Is.EqualTo(0));
		}

		[Test]
		[TestCase('a', 50)]
		[TestCase('b', 30)]
		[TestCase('c', 20)]
		public void Scan_should_return_expected_price_for_item(char item, int expected)
		{
			var actual = new Scanner().Scan(item);
			Assert.That(actual, Is.EqualTo(expected));
		}
	}

	class Scanner
	{
		private readonly Dictionary<char, int> _prices = new Dictionary<char, int>
			{
				{'a', 50},
				{'b', 30},
				{'c', 20}
			};

		public int Scan()
		{
			return 0;
		}

		public int Scan(char item)
		{
			return _prices[item];
		}
	}
}
