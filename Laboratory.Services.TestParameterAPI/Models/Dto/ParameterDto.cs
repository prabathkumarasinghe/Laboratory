using System.ComponentModel.DataAnnotations;

namespace Laboratory.Services.TestParameterAPI.Models.Dto
{
	public class ParameterDto
	{

        [Key]
        public int Id { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int? RefNumber { get; set; }
        public int? LabNumber { get; set; }
        public int? Age { get; set; }
        public string? PatientName { get; set; }
        public string? TestType { get; set; }
        public string? Sex { get; set; }
        public DateOnly? CollectedDate { get; set; }
        public DateOnly? ReceivedDate { get; set; }
        public DateOnly? ReportedDate { get; set; }
        public DateOnly? DOB { get; set; }

        //lipid
        public double? TotalCholesterol { get; set; }
        public double? Triglycerides { get; set; }
        public double? HDL { get; set; }
        public double? LDL { get; set; }
        public double? CholHDLRatio { get; set; }
        public double? NonHDLChol { get; set; }
        //LFT
        public double? ALP { get; set; }
        public double? GGT { get; set; }
        public double? LD { get; set; }
        public double? AST { get; set; }
        public double? ALT { get; set; }
        public double? TotalProtein { get; set; }
        public double? Albumin { get; set; }
        public double? Globulin { get; set; }
        public double? Sodium { get; set; }
        public double? Potassium { get; set; }
        public double? Glucose { get; set; }
        //FBC
        public double? WBC { get; set; }
        public double? Neutrophils { get; set; }
        public double? Lymphocytes { get; set; }
        public double? Eosinophils { get; set; }
        public double? RBC { get; set; }
        public double? Hb { get; set; }
        public double? MCV { get; set; }
        public double? HCT { get; set; }
        public double? MCH { get; set; }
        public double? PlateletCount { get; set; }
        public double? MPV { get; set; }
        // UFR
        public string? Color { get; set; }
        public double? SpecificGravity { get; set; }
        public string? Appearance { get; set; }
        public string? PH { get; set; }
        public string? Protien { get; set; }
        public string? Urobilinogen { get; set; }
        public string? Ketones { get; set; }
        public string? BileSalt { get; set; }
        public string? Bilirubin { get; set; }
        public string? Nitrite { get; set; }
        public string? PusCells { get; set; }
        public string? RedBloodCells { get; set; }
        public string? EpithelialCells { get; set; }
        public string? Casts { get; set; }
        public string? Crystals { get; set; }
        public string? Bacteria { get; set; }

        public string? RheumatoidFactor { get; set; }

        public double? CReactiveProtein { get; set; }

        public double? Esr1stHour { get; set; }

        public double? SCreatinine { get; set; }

        public double? EstimateGfr { get; set; }

        public double? SgotAST { get; set; }

        public double? SgptALT { get; set; }

        //  BLOOD GLUCOSE
        public double? RandomBloodSugar { get; set; }

        //  BLOOD GLUCOSE
        public double? PostPrandialBloodSugar { get; set; }

        // WIDAL(SAT)  Test
        public double? SCreningSltdeMethod { get; set; }
        public string? SalmonellaTyphl { get; set; }
        public string? SalmonellaTyphlH { get; set; }
        public string? SalmonellaParaTyphlI { get; set; }


        public double? Haemoglobin { get; set; }

        public string? RhematoidFactor { get; set; }

        //BLOOD GLUCOSE
        public double? FastingBloodGlucose { get; set; }
        public double? BreakFastSample { get; set; }
        public double? LunchSample { get; set; }
        public double? DinnerSample { get; set; }
    }
}
