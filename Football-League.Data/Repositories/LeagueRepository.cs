using Football_League.Data.Interfaces;
using Football_League.Models.Domain;
using Football_League.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.Data.Repositories
{
    public class LeagueRepository : ILeagueRepository
    {
        private readonly AppDbContext _appDbContext;

        public LeagueRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task DeleteAsync(League League)
        {
            _appDbContext.Leagues.Remove(League);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task EditAsync(League League)
        {
            _appDbContext.Leagues.Update(League);
            await _appDbContext.SaveChangesAsync();
        }

        public IEnumerable<League> GetAll()
            => _appDbContext.Leagues.Include(x => x.Teams);

        public League GetByName(string name)
            => _appDbContext.Leagues.Include(x => x.Teams).SingleOrDefault(l => l.Name == name);

        public League GetById(int id)
            => _appDbContext.Leagues.Include(x => x.Teams).SingleOrDefault(l => l.Id == id);

        public async Task InsertAsync(League League)
        {
            await _appDbContext.Leagues.AddAsync(League);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
