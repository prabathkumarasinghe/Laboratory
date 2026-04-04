using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Laboratory.Services.TestParameterAPI.Models
{
    public class Parameter
    {
        [Key]
        public int Id { get; set; }

        // ================= PATIENT DETAILS =================
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


        // ================= BLOOD SUGAR =================
        public double? GTT_1stHour { get; set; }
        public double? GTT_2ndHour { get; set; }


        // Blood Sugar Series
        public double? FBS { get; set; }
        public double? PostBreakfast { get; set; }
        public double? PostLunch { get; set; }
        public double? PostDinner { get; set; }


        // ================= LIPID PROFILE =================
        public double? TotalCholesterol { get; set; }
        public double? Triglycerides { get; set; }
        public double? HDL { get; set; }
        public double? LDL { get; set; }
        public double? VLDL { get; set; }
        public double? CholHDLRatio { get; set; }
        public double? NonHDLChol { get; set; }


        // ================= ELECTROLYTES =================
        public double? Sodium { get; set; }
        public double? Potassium { get; set; }


        // ================= CRP =================
        public double? CReactiveProtein { get; set; }


        // ================= CALCIUM =================
        public double? SerumCalcium { get; set; }


        // ================= RENAL FUNCTION (EGFR)=================
        public double? SerumCreatinine { get; set; }
        public double? GFR { get; set; }


        // ================= LIVER FUNCTION =================
        public double? TotalProtein { get; set; }
        public double? Albumin { get; set; }
        public double? Globulin { get; set; }
        public double? SGOT { get; set; }
        public double? SGPT { get; set; }
        public double? TotalBilirubin { get; set; }
        public double? DirectBilirubin { get; set; }
        public double? IndirectBilirubin { get; set; }
        public double? AlkalinePhosphatase { get; set; }
        public double? GGT { get; set; }


        // ================= ESR =================
        public double? ESR { get; set; }


        // =================PROTHROMBIN TIME & INR =================
        public double? ProthrombinTime { get; set; }
        public double? ControlTime { get; set; }
        public double? INR { get; set; }


        // ================= FULL BLOOD COUNT =================
        public double? Hemoglobin { get; set; }
        public double? PCV { get; set; }
        public double? PlateletCount { get; set; }
        public double? WBC { get; set; }
        public double? Neutrophils { get; set; }
        public double? Lymphocytes { get; set; }
        public double? Eosinophils { get; set; }
        public double? Monocytes { get; set; }
        public double? Basophils { get; set; }
        public double? RBC { get; set; }
        public double? MCV { get; set; }
        public double? MCH { get; set; }
        public double? MCHC { get; set; }


        // ================= FBC ADVANCED =================
        public double? LymphPercent { get; set; }
        public double? MIDPercent { get; set; }
        public double? GranPercent { get; set; }
        public double? LymphAbsolute { get; set; }
        public double? MIDAbsolute { get; set; }
        public double? GranAbsolute { get; set; }
        public double? HCT { get; set; }
        public double? RDW_CV { get; set; }
        public double? RDW_SD { get; set; }
        public double? PLT { get; set; }
        public double? MPV { get; set; }
        public double? PDW { get; set; }
        public double? PCT { get; set; }


        // ================= HCG =================
        public bool? IsPregnant { get; set; }


        // ================= URINE FULL REPORT =================
        public string? UrineColor { get; set; }
        public string? Transparency { get; set; }
        public string? Mucous { get; set; }
        public double? SpecificGravity { get; set; }
        public string? Reaction { get; set; }
        public string? UrineProtein { get; set; }
        public string? ReducingSubstances { get; set; }
        public string? KetoneBodies { get; set; }
        public string? UrineBilirubin { get; set; }
        public string? Urobilinogen { get; set; }
        public string? PusCells { get; set; }
        public string? RedCells { get; set; }
        public string? EpithelialCells { get; set; }
        public string? Organisms { get; set; }
        public string? Crystals { get; set; }
        public string? Casts { get; set; }
        public string? YeastCells { get; set; }


        //=========Blood Glucose =========

        public string? FBG { get; set; }
        public string? PPBG { get; set; }


        //=========glucose tolerance =================

        public string? FBSADGW { get; set; }
        public string? FBS1 { get; set; }
        public string? FBS2 { get; set; }


        //=========HAEMOGLOBIN CONCENTRATION(HGB)=========
        public string? HGB { get; set; }


        //=========PPBS=========
        public double? PPBS { get; set; }


        // =========RBS=========
        public double? RBS { get; set; }

    }


















}
