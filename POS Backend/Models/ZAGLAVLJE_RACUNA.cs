using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS_Backend.Models
{
    [Index(nameof(Broj), IsUnique = true)]
    public class ZAGLAVLJE_RACUNA
    {
        [Key]
        public int Id { get; set; }
        public int Broj { get; set; }
        [Required]
        public DateTime Datum { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Napomena { get; set; }
        [Required]
        public int KupacId { get; set; }
        public KUPAC Kupac { get; set; }
    }
}
