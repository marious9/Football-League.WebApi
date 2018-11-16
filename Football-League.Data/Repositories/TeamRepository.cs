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
    public class TeamRepository : ITeamRepository
    {
        private readonly AppDbContext _appDbContext;

        public TeamRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task DeleteAsync(Team Team)
        {
            _appDbContext.Teams.Remove(Team);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task EditAsync(Team Team)
        {
            _appDbContext.Teams.Update(Team);
            await _appDbContext.SaveChangesAsync();
        }

        public IEnumerable<Team> GetAll()
            => _appDbContext.Teams.Include(t => t.AwayMatches).Include(t => t.HostMatches).Include(t => t.League);

        public Team GetById(int id)
            => _appDbContext.Teams.Include(t => t.AwayMatches).ThenInclude(m => m.Away)
                                  .Include(t => t.AwayMatches).ThenInclude(m => m.Host)
                                  .Include(t => t.HostMatches).ThenInclude(m => m.Host)
                                  .Include(t => t.HostMatches).ThenInclude(m => m.Away)
                                  .Include(t => t.League)
                                  .Include(t => t.Players)
                                  .SingleOrDefault(m => m.Id == id);

        public IEnumerable<Team> GetTeamsFromLeague(int leagueId)
            => GetAll().Where(t => t.League.Id == leagueId);

        public async Task InsertAsync(Team Team)
        {
            _appDbContext.Teams.Add(Team);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
