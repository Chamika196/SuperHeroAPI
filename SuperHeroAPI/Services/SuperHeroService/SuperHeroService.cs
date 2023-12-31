﻿using SuperHeroAPI.Data;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
       

        private readonly DataContext _context;
        public SuperHeroService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            _context.SuperHeros.Add(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeros.ToListAsync();
        }

        public async Task<List<SuperHero>?> DeleteHero(int id)
        {
            var hero = await _context.SuperHeros.FindAsync(id);


            if (hero == null)
            {
                return null;
            }
            _context.SuperHeros.Remove(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeros.ToListAsync();
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeros.ToListAsync();
            return heroes;
        }

        public async Task<SuperHero?> GetSingleHero(int id)
        {
            var hero =await _context.SuperHeros.FindAsync(id);
            if (hero == null)
            {
                return null;
            }
            return hero;
        }

        public async Task<List<SuperHero>?> UpdateHero(int id, SuperHero request)
        {

            var hero = await _context.SuperHeros.FindAsync(id);


            if (hero == null)
            {
                return null;
            }

            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;

            await _context.SaveChangesAsync();

            return await _context.SuperHeros.ToListAsync();
        }
    }
}
