using System.ComponentModel.DataAnnotations;

namespace Laboratory.Web.Models
{
   

    public class LipidProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        //[Required]
        //[Display(Name = "Total Cholesterol (mg/dL)")]
        //public decimal TotalCholesterol { get; set; }

        //[Required]
        //[Display(Name = "HDL (High-Density Lipoprotein) (mg/dL)")]
        //public decimal HDL { get; set; }

        //[Required]
        //[Display(Name = "LDL (Low-Density Lipoprotein) (mg/dL)")]
        //public decimal LDL { get; set; }

        //[Required]
        //[Display(Name = "Triglycerides (mg/dL)")]
        //public decimal Triglycerides { get; set; }
    }

}
