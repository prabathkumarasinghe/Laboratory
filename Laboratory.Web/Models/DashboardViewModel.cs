using System;
using System.Collections.Generic;

namespace Laboratory.Web.Models
{
    public class DashboardViewModel
    {
        public int? TotalTests { get; set; }
        public int? PendingOrders { get; set; }
        public int? CompletedOrders { get; set; }
        public int? PendingSamples { get; set; }
        public int? CartItems { get; set; }
        public int? PatientsToday { get; set; }

        public int TestsToday { get; set; }

        public int PendingResults { get; set; }

        public int CompletedReports { get; set; }

        public int BloodTests { get; set; }

        public int UrineTests { get; set; }

        public List<ParameterDto> RecentPatients { get; set; } = new();

        public List<OrderSummary> RecentOrders { get; set; } = new List<OrderSummary>();
        public List<TestSummary> UpcomingTests { get; set; } = new List<TestSummary>();

        // Dashboard Cards
        //public int PatientsToday { get; set; }
        //public int TestsToday { get; set; }
        //public int PendingResults { get; set; }
        //public int CompletedReports { get; set; }

        // Today's Test Statistics
        public int BloodSugarTests { get; set; }
        public int GTTTests { get; set; }
        public int BloodSugarSeriesTests { get; set; }
        public int LipidProfileTests { get; set; }
        public int ElectrolyteTests { get; set; }
        public int CRPTests { get; set; }
        public int CalciumTests { get; set; }
        public int RenalFunctionTests { get; set; }
        public int LiverFunctionTests { get; set; }
        public int ESRTests { get; set; }
        public int PTINRTests { get; set; }
        public int FullBloodCountTests { get; set; }
        public int FBCAdvancedTests { get; set; }
        public int HCGTests { get; set; }
        public int UrineReportTests { get; set; }
        public int GlucoseTests { get; set; }
        public int GTTExtendedTests { get; set; }
        public int HGBTests { get; set; }
        public int PPBSTests { get; set; }
        public int RBSTests { get; set; }

        // Recent Patients
        //public List<ParameterDto> RecentPatients { get; set; } = new();

        // Pending Patients
        public List<ParameterDto> PendingPatients { get; set; } = new();

    }

    public class OrderSummary
    {
        public string OrderId { get; set; }
        public string Patient { get; set; }
        public string Test { get; set; }
        public string Status { get; set; }
        public DateTime? Date { get; set; }
    }

    public class TestSummary
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
