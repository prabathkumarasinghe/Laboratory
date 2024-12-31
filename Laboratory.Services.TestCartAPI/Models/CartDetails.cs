using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Laboratory.Services.TestCartAPI.Models.Dto;

namespace Laboratory.Services.TestCartAPI.Models
{
	public class CartDetails
	{
		[Key]
		public int CartDetailsId { get; set; }
		public int CartHeaderId { get; set; }
		[ForeignKey("CartHeaderId")]
		public CartHeader CartHeader { get; set; }
		public int TestId { get; set; }
		[NotMapped]
		public TestDto Test { get; set; }
		public int Count { get; set; }

	}
}
