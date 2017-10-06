using System.ComponentModel.DataAnnotations;

namespace Vidly.WebApp.Models
{
    public class MemberShipType
    {
        public byte Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}