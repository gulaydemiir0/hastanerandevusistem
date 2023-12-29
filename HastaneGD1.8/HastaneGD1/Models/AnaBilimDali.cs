﻿using System.ComponentModel.DataAnnotations;

namespace HastaneGD1.Models
{
    public class AnaBilimDali
    {
        [Key]
        public int abdId { get; set; }
        [Required]
        //anabilim dalı adı
        public string abdName { get; set; }

    }
}
