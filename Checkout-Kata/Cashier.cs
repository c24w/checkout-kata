namespace Checkout_Kata
{
	class Cashier : ICashier
	{
		private readonly ICheckout _checkout;

		public Cashier(ICheckout checkout)
		{
			_checkout = checkout;
		}

		public int ScanBasket(string basket = "")
		{
			return _checkout.Total(basket) - _checkout.Discount(basket);
		}

	}
}