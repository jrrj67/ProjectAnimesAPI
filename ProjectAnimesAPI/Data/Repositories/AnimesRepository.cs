using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectAnimesAPI.Data.Context;
using ProjectAnimesAPI.Data.Exceptions;
using ProjectAnimesAPI.Data.Interfaces;
using ProjectAnimesAPI.Models;

namespace ProjectAnimesAPI.Data.Repositories
{
    public class AnimesRepository : IAnimesRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly Validation<Anime> _validation;

        public AnimesRepository(ApplicationDbContext context, Validation<Anime> validation)
        {
            _context = context;
            _validation = validation;
        }
        
        public async Task<List<Anime>> GetAll()
        {
            return await _context.Animes.ToListAsync();
        }

        public async Task<Anime> Create(Anime anime)
        {
            _validation.Validate(anime);
            
            _context.Add(anime);
            
            await _context.SaveChangesAsync();
            
            return anime;
        }

        public async Task<Anime> Update(Anime anime, int id)
        {
            _validation.Validate(anime);
            
            var animeContext = await _context.Animes.FirstOrDefaultAsync(a => a.Id == id);
            
            if (animeContext == null)
                throw new NotFoundException("Anime not found!");

            animeContext.Name = anime.Name;
            
            await _context.SaveChangesAsync();
            
            return animeContext;
        }

        public async Task<Anime> Delete(int id)
        {
            var animeContext = await _context.Animes.FirstOrDefaultAsync(a => a.Id == id);
            
            if (animeContext == null)
                throw new NotFoundException("Anime not found!");

            _context.Animes.Remove(animeContext);

            await _context.SaveChangesAsync();

            return animeContext;
        }

        public async Task<Anime> GetById(int id)
        {
            var animeContext = await _context.Animes.FirstOrDefaultAsync(a => a.Id == id);
            
            if (animeContext == null)
                throw new NotFoundException("Anime not found!");

            return animeContext;
        }
    }
}