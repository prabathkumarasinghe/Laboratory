

namespace Laboratory.Web.Models
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
        public int? TotalCholesterol { get; set; }
        public int? Triglycerides { get; set; }
        public int? HDL { get; set; }
        public int? LDL { get; set; }
        public int? CholHDLRatio { get; set; }
        public int? NonHDLChol { get; set; }
    }
}
