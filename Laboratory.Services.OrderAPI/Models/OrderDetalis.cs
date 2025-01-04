using Laboratory.Services.OrderAPI.Models.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laboratory.Services.OrderAPI.Models
{
    public class OrderDetalis
    {
        [Key]
        public int OrderDetailsId { get; set; }
        public int OrderHeaderId { get; set; }
        [ForeignKey("OrderHeaderId")]
        public OrderHeader? OrderHeader { get; set; }
        public int TestId { get; set; }
        [NotMapped]
        public TestDto? Test { get; set; }
        public int Count { get; set; }
        public string TesttName { get; set; }
        public double Price { get; set; }
    }
}
