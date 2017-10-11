using System.ComponentModel.DataAnnotations;

namespace Vidly.WebApp.Models.Dtos
{
    public class MemberShipTypeDto
    {
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;

        public byte Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
    }
}