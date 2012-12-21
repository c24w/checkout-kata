using NUnit.Framework;

namespace Checkout_Kata
{
	[TestFixture]
	public class CheckoutKataTests
	{
		[Test]
		[TestCase('a', 50)]
		[TestCase('b', 30)]
		public void Scan_should_return_50_for_a(char item, int expected)
		{
			var actual = Scan(item);
			Assert.That(actual, Is.EqualTo(expected));
		}

		private int Scan(char item)
		{
			if (item == 'b')
				return 30;
			return 50;
		}
	}
}
