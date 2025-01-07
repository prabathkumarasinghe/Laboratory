namespace Laboratory.Web.Models
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
    }
}
