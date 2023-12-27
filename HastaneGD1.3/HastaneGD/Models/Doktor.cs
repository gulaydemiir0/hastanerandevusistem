using System.ComponentModel.DataAnnotations;

namespace HastaneGD.Models
{
    public class Doktor
    {
        [Key]
        public int doktorId { get; set; }
        // Doktor Adı//
        [Required]
        public string doktorName { get; set; }
        [Required] 
        public int  abdID { get; set; }
        virtual public ICollection<AnaBilimDali> AnaBilimDalis { get; set; }    

        public int polID { get; set; }
        virtual public ICollection<Poliklinik> Polikliniks { get; set; }  

        



    }
}
