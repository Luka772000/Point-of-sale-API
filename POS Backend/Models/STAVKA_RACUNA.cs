namespace POS_Backend.Models
{
    public class STAVKA_RACUNA
    {
        public int ProizvodId { get; set; }
        public PROIZVOD Proizvod { get; set; }
        public int RacunId { get; set; }
        public STAVKE_RACUNA Racun { get; set; }
    }
}
