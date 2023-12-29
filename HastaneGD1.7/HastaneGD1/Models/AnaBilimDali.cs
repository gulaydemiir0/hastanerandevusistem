using System.ComponentModel.DataAnnotations;

namespace HastaneGD1.Models
{
    public class AnaBilimDali
    {
        [Key]
        // Ana Bilim dalı id
        public int abdId { get; set; }
        [Required]
        public string abdName { get; set; }

    }
}
