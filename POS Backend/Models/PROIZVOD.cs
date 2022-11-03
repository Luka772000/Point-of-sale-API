using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS_Backend.Models
{
    [Index(nameof(Sifra), IsUnique = true)]
    public class PROIZVOD
    {
        [Key]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sifra { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public string JedinicaMjere { get; set; }
        [Required]
        public decimal Cijena { get; set; }
        [Required]
        public int Stanje { get; set; }
        public List<STAVKA_RACUNA> StavkeRacuna {get;set;}
    }
}
