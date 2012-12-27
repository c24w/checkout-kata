namespace Checkout_Kata
{
	internal interface IItemDiscount
	{
		char ItemCode { get; set; }
		int DiscountQuantity { get; set; }
		int DiscountValue { get; set; }
	}
}