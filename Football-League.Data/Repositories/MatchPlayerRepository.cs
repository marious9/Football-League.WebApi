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
    public class MatchPlayerRepository : IMatchPlayerRepository
    {
        private readonly AppDbContext _appDbContext;

        public MatchPlayerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task DeleteAsync(MatchPlayer MatchPlayer)
        {
            _appDbContext.MatchPlayers.Remove(MatchPlayer);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task EditAsync(MatchPlayer MatchPlayer)
        {
            _appDbContext.MatchPlayers.Update(MatchPlayer);
            await _appDbContext.SaveChangesAsync();
        }

        public IEnumerable<MatchPlayer> GetAll()
            => _appDbContext.MatchPlayers;

        public MatchPlayer GetById(int matchId, int playerId)
            => _appDbContext.MatchPlayers.Include(m => m.Match).Include(m => m.Player).SingleOrDefault(l => l.MatchId == matchId && l.PlayerId == playerId);

        public async Task InsertAsync(MatchPlayer MatchPlayer)
        {
            _appDbContext.MatchPlayers.Add(MatchPlayer);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
