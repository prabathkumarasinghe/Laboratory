using System.ComponentModel.DataAnnotations;

namespace Laboratory.Services.TestParameterAPI.Models
{
	public class Parameter
	{
		[Key]
		public int TestId { get; set; }
		[Required]
        public int? RefNumber { get; set; }
        [Required]
        public int? LabNumber { get; set; }
        [Required]
        public string? Name { get; set; }
        public int? TotalCholesterol { get; set; }
        public int? Triglycerides { get; set; }
        public int? HDL { get; set; }
        public int? LDL { get; set; }
        public int? CholHDLRatio { get; set; }
        public int? NonHDLChol { get; set; }
        public int? ALP { get; set; }
        public int? GGT { get; set; }
        public int? LD { get; set; }
        public int? AST { get; set; }
        public int? ALT { get; set; }
        public int? TotalProtein { get; set; }
        public int? Albumin { get; set; }
        public int? Globulin { get; set; }
        public int? Sodium { get; set; }
        public int? Potassium { get; set; }
       
    }
}
