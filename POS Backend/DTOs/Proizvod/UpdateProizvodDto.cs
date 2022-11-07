using System.ComponentModel.DataAnnotations;

namespace POS_Backend.DTOs.Proizvod
{
    public class UpdateProizvodDto
    {
        public int Id { get; set; }
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
