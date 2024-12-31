namespace Laboratory.Web.Models
{
	public class CartDetailsDto
	{
		public int CartDetailsId { get; set; }
		public int CartHeaderId { get; set; }
		public CartHeaderDto? CartHeader { get; set; }
		public int TestId { get; set; }
		public TestDto? Test { get; set; }
		public int Count { get; set; }
	}
}
