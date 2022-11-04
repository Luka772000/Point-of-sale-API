using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using POS_Backend.DTOs.Racun.Creating;
using POS_Backend.Interfaces;
using System.Threading.Tasks;

namespace POS_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacunController : ControllerBase
    {

        private readonly ILogger<RacunController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public RacunController(ILogger<RacunController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<ActionResult> CreateRacun(ZaglavljeRacunaDto racunDto)
        {
            _logger.LogInformation("Kreiranje Racuna ");
            try
            {
               await _unitOfWork.Racuni.CreateRacun(racunDto);
                _unitOfWork.Complete();
                return Ok();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetRacunList()
        {
            _logger.LogInformation("Pokusaj vracanja RacunList");
            try
            {
                var racuni = await _unitOfWork.Racuni.GetAllZaglavlja();
                return Ok(racuni);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");
                return BadRequest(ex.Message);
            }
        }
    }
}
