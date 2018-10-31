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
    public class PlayerRepository : IPlayerRepository 
    {
        private readonly AppDbContext _appDbContext;

        public PlayerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task DeleteAsync(Player Player)
        {
            _appDbContext.Players.Remove(Player);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task EditAsync(Player Player)
        {
            _appDbContext.Players.Update(Player);
            await _appDbContext.SaveChangesAsync();
        }

        public IEnumerable<Player> GetAll()
            => _appDbContext.Players.Include(p => p.MatchPlayers);

        public Player GetById(int id)
            => _appDbContext.Players.Include(p => p.MatchPlayers).SingleOrDefault(p => p.Id == id);

        public async Task InsertAsync(Player Player)
        {
            _appDbContext.Players.Add(Player);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
