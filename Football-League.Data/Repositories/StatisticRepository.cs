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
    public class StatisticRepository : IStatisticRepository
    {
        private readonly AppDbContext _appDbContext;

        public StatisticRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task DeleteAsync(Statistic Statistic)
        {
            _appDbContext.Statistics.Remove(Statistic);
            _appDbContext.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task EditAsync(Statistic Statistic)
        {
            _appDbContext.Statistics.Update(Statistic);
            _appDbContext.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Statistic>> GetAllAsync()
            => await Task.FromResult(_appDbContext.Statistics.Include(s => s.MatchPlayer));

        public async Task<Statistic> GetByIdAsync(int id)
            => await Task.FromResult(_appDbContext.Statistics.Include(s => s.MatchPlayer).SingleOrDefault(s => s.Id == id));

        public async Task InsertAsync(Statistic Statistic)
        {
            _appDbContext.Statistics.Add(Statistic);
            _appDbContext.SaveChanges();
            await Task.CompletedTask;
        }
    }
}
