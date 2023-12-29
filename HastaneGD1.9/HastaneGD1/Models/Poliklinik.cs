using System.ComponentModel.DataAnnotations;

namespace HastaneGD1.Models
{
    public class Poliklinik
    {
        [Key]
        public int polId { get; set; }
        [Required]
        public string polName { get; set;}


    }
}
