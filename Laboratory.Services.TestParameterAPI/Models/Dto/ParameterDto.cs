using System.ComponentModel.DataAnnotations;

namespace Laboratory.Services.TestParameterAPI.Models.Dto
{
	public class ParameterDto
	{

		public int Id { get; set; }
		public string? Phone { get; set; }
		public string? Email { get; set; }
		public int? RefNumber { get; set; }
      
        public int? LabNumber { get; set; }
  
        public string? PatientName { get; set; }
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
        public int? WBC { get; set; }
        public int? Neutrophils { get; set; }
        public int? Lymphocytes { get; set; }
        public int? Eosinophils { get; set; }
        public int? RBC { get; set; }
        public int? Hb { get; set; }
        public int? MCV { get; set; }
        public int? HCT { get; set; }
        public int? MCH { get; set; }
        public int? PlateletCount { get; set; }
        public int? MPV { get; set; }
    }
}
