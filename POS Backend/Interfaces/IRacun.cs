using POS_Backend.DTOs.ZaglavljeRacunaDto;
using System.Threading.Tasks;

namespace POS_Backend.Interfaces
{
    public interface IRacun
    {
        public Task CreateRacun(ZaglavljeRacunaDto racunDto);
    }
}
