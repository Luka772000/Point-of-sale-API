using POS_Backend.DTOs.Proizvod;
using System.ComponentModel.DataAnnotations;

namespace POS_Backend.DTOs.Racun
{
    public class STAVKA_RACUNADto
    {
        [Required]
        public int Kolicina { get; set; }
        [Required]
        public int Cijena { get; set; }
        public double? Popust { get; set; }
        public decimal IznosPopusta { get; set; }
        [Required]
        public int Vrijednost { get; set; }
        public int ZaglavljeRacunaId { get; set; }

        [Required]
        public int ProizvodId { get; set; }
        public GetProizvodDto Proizvod { get; set; }
    }
}
