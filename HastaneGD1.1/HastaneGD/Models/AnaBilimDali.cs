﻿using System.ComponentModel.DataAnnotations;

namespace HastaneGD.Models
{
    public class AnaBilimDali
    {
        [Key]
        // Anabilim dalı id //
        public int abdId { get; set; }
        [Required]
        public string abdName { get; set; }
        
        public virtual List<Doktor> Doktors { get; set; }

    }
}
