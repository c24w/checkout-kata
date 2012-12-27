namespace Checkout_Kata
{
	class ItemDiscount : IItemDiscount
	{
		public char ItemCode { get; set; }
		public int DiscountQuantity { get; set; }
		public int DiscountValue { get; set; }
	}
}