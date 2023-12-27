using System.ComponentModel.DataAnnotations;

namespace HastaneGD.Models
{
    public class Doctor
    {
     
       [Key]
        public int DoctorId { get; set; }

        [Required]
        public string DoctorName { get; set;}

        [Required]
        public string polName { get; set;}

    
    
    }
}
