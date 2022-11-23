using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS_Backend.DTOs.Proizvod;
using POS_Backend.DTOs.Racun.Creating;
using POS_Backend.DTOs.Racun.Getting;
using POS_Backend.Interfaces;
using POS_Backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS_Backend.Repositories
{
    public class RacunRepository : GenericRepository<ZaglavljeRacuna>, IRacun
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
            var user = await _context.AppUsers.Where(i => i.Id == racunDto.UserId).SingleOrDefaultAsync();
            if (kupac == null)
            {
                throw new System.Exception("Kupac nije pronadjen");
            }
            var zagRacuna = new ZaglavljeRacuna
            {
                Datum = racunDto.Datum,
                Kupac = kupac,
                KupacId = racunDto.KupacId,
                Napomena = racunDto.Napomena,
                UkupnaCijena = racunDto.UkupnaCijena,
                User = user,
            };
            await _context.ZaglavljaRacuna.AddAsync(zagRacuna);
            await _context.SaveChangesAsync();
            foreach (var item in racunDto.StavkeRacuna)
            {
                var proizvod = await _context.Proizvodi.Where(u => u.Id == item.ProizvodId).SingleOrDefaultAsync();
                
                if (proizvod == null)
                {
                    throw new System.Exception("Proizvod nije pronadjen");
                }
                var stavkaRacuna = new StavkaRacuna
                {
                    Naziv = item.Naziv,
                    Kolicina = item.Kolicina,
                    Proizvod = proizvod,
                    ProizvodId = item.ProizvodId,
                    Cijena = proizvod.Cijena,
                    Popust = item.Popust,
                    IznosPopusta = item.IznosPopusta,
                    Vrijednost = item.Vrijednost,
                    ZaglavljeRacuna = zagRacuna,
                    ZaglavljeRacunaId = zagRacuna.Id,
                };
                proizvod.Stanje = proizvod.Stanje - item.Kolicina;
                await _context.StavkeRacuna.AddAsync(stavkaRacuna);
                await _context.SaveChangesAsync();

                zagRacuna.StavkeRacuna.Add(stavkaRacuna);
                await _context.SaveChangesAsync();

            }
        }
        public async Task<IEnumerable<GetZaglavljeRacunaDto>> GetAllZaglavlja()
        {
            return await _context.ZaglavljaRacuna.ProjectTo<GetZaglavljeRacunaDto>(_mapper.ConfigurationProvider).OrderByDescending(i=>i.Datum).ToListAsync();
        }
        public async Task DeleteRacun(int id)
        {
            var racun = await _context.ZaglavljaRacuna.FirstOrDefaultAsync(u => u.Id == id);
            _context.ZaglavljaRacuna.Remove(racun);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<GetJedinicaDto>> GetJedinice()
        {
            return await _context.JediniceMjere.ProjectTo<GetJedinicaDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
