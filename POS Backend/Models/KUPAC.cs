using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS_Backend.Models
{
    [Index(nameof(Sifra), IsUnique = true)]
    public class KUPAC
    {
        [Key]
        public int Id { get; set; }
        
        public int Sifra { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Naziv { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Adresa { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Mjesto { get; set; }
        public List<ZAGLAVLJE_RACUNA> ZaglavljeRacuna { get; set; }
    }
}
