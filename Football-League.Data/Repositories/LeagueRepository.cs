using Football_League.Data.Interfaces;
using Football_League.Models.Domain;
using Football_League.Repositories.Data;
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
            _appDbContext.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task EditAsync(League League)
        {
            _appDbContext.Leagues.Update(League);
            _appDbContext.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<League>> GetAllAsync()
            => await Task.FromResult(_appDbContext.Leagues);

        public async Task<League> GetByIdAsync(int id)
            => await Task.FromResult(_appDbContext.Leagues.SingleOrDefault(l => l.Id == id));

        public async Task InsertAsync(League League)
        {
            _appDbContext.Leagues.Add(League);
            _appDbContext.SaveChanges();
            await Task.CompletedTask;
        }
    }
}
