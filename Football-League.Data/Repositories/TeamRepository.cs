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
            _appDbContext.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task EditAsync(Team Team)
        {
            _appDbContext.Teams.Update(Team);
            _appDbContext.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
            => await Task.FromResult(_appDbContext.Teams.Include(t => t.Matches));

        public async Task<Team> GetByIdAsync(int id)
            => await Task.FromResult(
                                _appDbContext.Teams
                                .Include(m => m.Matches)
                                .SingleOrDefault(m => m.Id == id));

        public async Task InsertAsync(Team Team)
        {
            _appDbContext.Teams.Add(Team);
            _appDbContext.SaveChanges();
            await Task.CompletedTask;
        }
    }
}
