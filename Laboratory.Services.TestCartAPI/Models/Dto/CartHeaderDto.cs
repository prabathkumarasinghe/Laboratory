using System.ComponentModel.DataAnnotations;

namespace Laboratory.Services.TestCartAPI.Models.Dto
{
	public class CartHeaderDto
	{
		public int CartHeaderId { get; set; }
		public string? UserId { get; set; }
		public double CartTotal { get; set; }
        public int? RefNumber { get; set; }
        public int? LabNumber { get; set; } 
        public string? Name { get; set; }
		public string? Phone { get; set; }
		public string? Email { get; set; }
	}
}
