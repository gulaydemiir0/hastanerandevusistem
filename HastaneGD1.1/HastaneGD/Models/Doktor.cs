using System.ComponentModel.DataAnnotations;

namespace HastaneGD.Models
{
    public class Doktor
    {
        [Key]
        public int doktorId { get; set; }

        [Required]
        public string doktorName { get; set; }
        [Required] 
        public int  abdID { get; set; }
        public virtual AnaBilimDali AnaBilimDali { get; set; }  

        public int polId { get; set; }
        public virtual Poliklinik Poliklinik { get; set; }  



    }
}
