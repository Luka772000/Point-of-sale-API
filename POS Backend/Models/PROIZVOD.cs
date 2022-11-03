using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS_Backend.Models
{
    [Index(nameof(Sifra), IsUnique = true)]
    public class PROIZVOD
    {
        [Key]
        public int Id { get; set; }
        public int Sifra { get; set; }
        public string Naziv { get; set; }
        public string JedinicaMjere { get; set; }
        public decimal Cijena { get; set; }
        public int Stanje { get; set; }
        public List<STAVKA_RACUNA> StavkeRacuna {get;set;}
    }
}
