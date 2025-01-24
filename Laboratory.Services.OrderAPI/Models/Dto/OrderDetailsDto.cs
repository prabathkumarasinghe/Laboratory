namespace Laboratory.Services.OrderAPI.Models.Dto
{
    public class OrderDetailsDto
    {
        public int OrderDetailsId { get; set; }
        public int OrderHeaderId { get; set; }
        public int TestId { get; set; }
        public TestDto? Test { get; set; }
        public int Count { get; set; }
        public string TesttName { get; set; }
        public double Price { get; set; }
        public int? TotalCholesterol { get; set; }
        public int? Triglycerides { get; set; }
        public int? HDL { get; set; }
        public int? LDL { get; set; }
        public int? CholHDLRatio { get; set; }
        public int? NonHDLChol { get; set; }
    }
}
