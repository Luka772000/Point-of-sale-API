using System.ComponentModel.DataAnnotations;

namespace POS_Backend.DTOs.Proizvod
{
    public class UpdateProizvodDto
    {
        [Required]
        public string StariNaziv { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public string JedinicaMjere { get; set; }
        [Required]
        public decimal Cijena { get; set; }
        [Required]
        public int Stanje { get; set; }
        
    }
}
