using AutoMapper;
using Microsoft.EntityFrameworkCore;
using POS_Backend.DTOs.ZaglavljeRacunaDto;
using POS_Backend.Interfaces;
using POS_Backend.Models;
using System.Linq;
using System.Threading.Tasks;

namespace POS_Backend.Repositories
{
    public class RacunRepository : GenericRepository<ZAGLAVLJE_RACUNA>, IRacun
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public RacunRepository(Context context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task CreateRacun(ZaglavljeRacunaDto racunDto)
        {
            var kupac= await _context.Kupci.Where(u => u.Id == racunDto.KupacId).Include(i => i.ZaglavljeRacuna).SingleOrDefaultAsync();
            if (kupac == null)
            {
                throw new System.Exception("Kupac nije pronadjen");
            }
            var zagRacuna= new ZAGLAVLJE_RACUNA
            {
                Datum = racunDto.Datum,
                Kupac = kupac,
                KupacId = racunDto.KupacId,
                Napomena = racunDto.Napomena,
            };
            await _context.ZaglavljeRacuna.AddAsync(zagRacuna);
            foreach (var item in racunDto.StavkeRacuna)
            {
                var zaglavlje = await _context.ZaglavljeRacuna.Where(i => i.Id == item.ZaglavljeRacunaId).Include(i => i.StavkeRacuna).SingleOrDefaultAsync();
                var proizvod = await _context.Proizvodi.Where(u => u.Id == item.ProizvodId).SingleOrDefaultAsync();
                if (proizvod == null)
                {
                    throw new System.Exception("Proizvod nije pronadjen");
                }
                var stavkaRacuna = new STAVKA_RACUNA
                {   
                    
                    Kolicina = item.Kolicina,
                    Proizvod = proizvod,
                    ProizvodId = item.ProizvodId,
                    Cijena = proizvod.Cijena,
                    Popust = item.Popust,
                    IznosPopusta = item.IznosPopusta,
                    Vrijednost = (proizvod.Cijena * item.Kolicina) - item.IznosPopusta,
                    ZaglavljeRacuna= zaglavlje,
                    ZaglavljeRacunaId = zaglavlje.Id,
                };
                zagRacuna.StavkeRacuna.Add(stavkaRacuna);
            }
            //var actor = await _context.Actors.Where(u => u.Name == movieRoleDto.ActorName).SingleOrDefaultAsync();
            //if (actor == null)
            //{
            //    actor = new Actor
            //    {
            //        Name = movieRoleDto.ActorName
            //    };
            //    _context.Actors.Add(actor);
            //    await _context.SaveChangesAsync();
            //    actor = await _context.Actors.Where(u => u.Name == movieRoleDto.ActorName).SingleOrDefaultAsync();
            //}

            //var movieRole = new MovieRole
            //{
            //    MovieId = movieRoleDto.MovieId,
            //    ActorId = actor.Id,
            //    RoleName = movieRoleDto.RoleName,
            //    Actor = actor,
            //    Movie = movie
            //};
            //_context.MovieRoles.Add(movieRole);
            //movie.MovieRoles.Add(movieRole);
            //await _context.SaveChangesAsync();



        }
    }
}
