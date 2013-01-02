namespace Checkout_Kata
{
	internal interface ICheckout
	{
		int Total(string basket);
		int Discount(string basket);
	}
}