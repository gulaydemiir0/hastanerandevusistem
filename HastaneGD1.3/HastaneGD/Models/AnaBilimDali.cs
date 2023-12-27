using System.ComponentModel.DataAnnotations;

namespace HastaneGD.Models
{
    public class AnaBilimDali
    {
        [Key]
        public int abdId { get; set; }
        [Required]
        public string abdName { get; set; }

        virtual public List<AnaBilimDali> AnaBilimDalis { get; set; }
    }
}
