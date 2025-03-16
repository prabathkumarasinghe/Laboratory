namespace Laboratory.Services.OrderAPI.Models.Dto
{
    public class OrderHeaderDto
    {
        public int OrderHeaderId { get; set; }
        public string? UserId { get; set; }
     //   public string? CouponCode { get; set; }
     //   public double Discount { get; set; }
        public double OrderTotal { get; set; }
        public int? RefNumber { get; set; }
        public int? LabNumber { get; set; }
        public string? Name { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }
        public DateTime OrderTime { get; set; }
        public string? Status { get; set; }
        //public string? PaymentIntentId { get; set; }
        //public string? StripeSessionId { get; set; }
        public IEnumerable<OrderDetailsDto> OrderDetails { get; set; }
        public int? TotalCholesterol { get; set; }
        public int? Triglycerides { get; set; }
        public int? HDL { get; set; }
        public int? LDL { get; set; }
        public int? CholHDLRatio { get; set; }
        public int? NonHDLChol { get; set; }
    }
}
