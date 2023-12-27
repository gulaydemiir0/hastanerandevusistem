using System.ComponentModel.DataAnnotations;

namespace HastaneGD1.Models
{
    public class Randevu
    {
        [Key]
        public int Id { get; set; }
  
        [MaxLength(25)]
        public string? HastaAdi { get; set; }
      
        public string? HastaSoyadi { get; set; }
        //Randevu Tarihi
        public DateTime? RandevuTarihi { get; set; }
        public string? DoktorAdi { get; set; }
        public string? PoliklinikAdi { get ; set; }
        
        public bool Durum { get; set; }
    }
}
