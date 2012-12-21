using NUnit.Framework;

namespace Checkout_Kata
{
	[TestFixture]
	public class CheckoutKataTests
	{
		[Test]
		[TestCase('a', 50)]
		[TestCase('b', 30)]
		[TestCase('c', 20)]
		public void Scan_should_return_50_for_a(char item, int expected)
		{
			var actual = new Scanner().Scan(item);
			Assert.That(actual, Is.EqualTo(expected));
		}
	}

	class Scanner
	{
		public int Scan(char item)
		{
			if (item == 'b')
				return 30;
			if (item == 'c')
				return 20;
			return 50;
		}
	}
}
