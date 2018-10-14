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
            _appDbContext.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task EditAsync(MatchPlayer MatchPlayer)
        {
            _appDbContext.MatchPlayers.Update(MatchPlayer);
            _appDbContext.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<MatchPlayer>> GetAllAsync()
            => await Task.FromResult(_appDbContext.MatchPlayers);

        public async Task<MatchPlayer> GetByIdAsync(int matchId, int playerId)
            => await Task.FromResult(_appDbContext.MatchPlayers.SingleOrDefault(l => l.MatchId == matchId && l.PlayerId == playerId));

        public async Task InsertAsync(MatchPlayer MatchPlayer)
        {
            _appDbContext.MatchPlayers.Add(MatchPlayer);
            _appDbContext.SaveChanges();
            await Task.CompletedTask;
        }
    }
}
