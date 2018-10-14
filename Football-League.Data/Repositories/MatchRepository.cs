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
    public class MatchRepository : IMatchRepository
    {
        private readonly AppDbContext _appDbContext;
        public MatchRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task DeleteAsync(Match Match)
        {
            _appDbContext.Matches.Remove(Match);
            _appDbContext.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task EditAsync(Match Match)
        {
            _appDbContext.Matches.Update(Match);
            _appDbContext.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Match>> GetAllAsync()
            => await Task.FromResult(_appDbContext.Matches.Include(m => m.MatchPlayers));

        public async Task<Match> GetByIdAsync(int id)
            => await Task.FromResult(
                                _appDbContext.Matches.Include(m => m.MatchPlayers)
                                .SingleOrDefault(m => m.Id == id));

        public async Task InsertAsync(Match Match)
        {
            _appDbContext.Matches.Add(Match);
            _appDbContext.SaveChanges();
            await Task.CompletedTask;
        }
    }
}
