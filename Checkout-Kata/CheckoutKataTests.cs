using NUnit.Framework;

namespace Checkout_Kata
{
	[TestFixture]
    public class CheckoutKataTests
    {
		[Test]
		public void Scan_should_return_50_for_a()
		{
			var actual = Scan('a');
			var expected = 50;
			Assert.That(actual, Is.EqualTo(expected));
		}

		private int Scan(char item)
		{
			return 50;
		}
    }
}
