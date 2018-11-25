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
            await _appDbContext.SaveChangesAsync();
        }

        public async Task EditAsync(Match Match)
        {
            _appDbContext.Matches.Update(Match);
            await _appDbContext.SaveChangesAsync();
        }

        public IEnumerable<Match> GetAll()
            => _appDbContext.Matches.Include(m => m.MatchPlayers).Include(m => m.Away)
                                    .Include(m => m.Host).Include(m => m.League);

        public Match GetById(int id)
            => _appDbContext.Matches.Include(m => m.MatchPlayers).ThenInclude(m => m.Player)
                                    .Include(m => m.MatchPlayers).ThenInclude(m => m.Statistics)
                                    .Include(m => m.Away).Include(m=>m.Host).Include(m=>m.League)
                                    .SingleOrDefault(m => m.Id == id);

        public async Task InsertAsync(Match Match)
        {
            _appDbContext.Matches.Add(Match);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
