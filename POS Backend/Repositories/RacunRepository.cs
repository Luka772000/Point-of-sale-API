using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS_Backend.DTOs.Racun.Creating;
using POS_Backend.DTOs.Racun.Getting;
using POS_Backend.Interfaces;
using POS_Backend.Models;
using System.Collections.Generic;
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
            var kupac = await _context.Kupci.Where(u => u.Id == racunDto.KupacId).Include(i => i.ZaglavljeRacuna).SingleOrDefaultAsync();
            if (kupac == null)
            {
                throw new System.Exception("Kupac nije pronadjen");
            }
            var zagRacuna = new ZAGLAVLJE_RACUNA
            {
                Datum = racunDto.Datum,
                Kupac = kupac,
                KupacId = racunDto.KupacId,
                Napomena = racunDto.Napomena,
            };
            await _context.ZaglavljeRacuna.AddAsync(zagRacuna);
            await _context.SaveChangesAsync();
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
                    ZaglavljeRacuna = zaglavlje,
                    ZaglavljeRacunaId = zaglavlje.Id,
                };
                await _context.StavkeRacuna.AddAsync(stavkaRacuna);
                await _context.SaveChangesAsync();

                zaglavlje.StavkeRacuna.Add(stavkaRacuna);
                await _context.SaveChangesAsync();

            }
        }
        public async Task<IEnumerable<GetZaglavljeRacunaDto>> GetAllZaglavlja()
        {
            return await _context.ZaglavljeRacuna.ProjectTo<GetZaglavljeRacunaDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
