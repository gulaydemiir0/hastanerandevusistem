using System.ComponentModel.DataAnnotations;

namespace HastaneGD.Models
{
    public class Poliklinik
    {
        [Key]
        public int polId { get; set; }
        [Required]
        // Poliklinik Adı // 
        public string polName { get; set;}

        public virtual List<Doktor> doktors { get; set;}
    }
}
