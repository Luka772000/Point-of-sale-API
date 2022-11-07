using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS_Backend.DTOs.Proizvod
{
    public class GetProizvodDto
    {
        public int Id { get; set; }
        public int Sifra { get; set; }
        public string Naziv { get; set; }
        public string JedinicaMjere { get; set; }
        public decimal Cijena { get; set; }
        public int Stanje { get; set; }
    }
}
