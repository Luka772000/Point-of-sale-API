using POS_Backend.DTOs.Racun.Creating;
using POS_Backend.DTOs.Racun.Getting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POS_Backend.Interfaces
{
    public interface IRacun
    {
        public Task CreateRacun(ZaglavljeRacunaDto racunDto);
        public Task<IEnumerable<GetZaglavljeRacunaDto>> GetAllZaglavlja();
    }
}
