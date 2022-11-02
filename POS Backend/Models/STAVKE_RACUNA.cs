using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS_Backend.Models
{
    public class STAVKE_RACUNA
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Kolicina { get; set; }
        [Required]
        public int Cijena { get; set; }
        public double? Popust { get; set; }
        public decimal IznosPopusta { get; set; }
        [Required]
        public int Vrijednost { get; set; }
        public List<STAVKA_RACUNA> StavkeRacuna { get; set; }
    }
}
