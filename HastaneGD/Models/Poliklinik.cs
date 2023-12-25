using System.ComponentModel.DataAnnotations;

namespace HastaneGD.Models
{
    public class Poliklinik
    {
        [Key]
        public int polId { get; set; }
        [Required]
        public string polName { get; set;}

    }
}
