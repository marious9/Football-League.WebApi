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
            await _appDbContext.SaveChangesAsync();
        }

        public async Task EditAsync(Statistic Statistic)
        {
            _appDbContext.Statistics.Update(Statistic);
            await _appDbContext.SaveChangesAsync();            
        }

        public IEnumerable<Statistic> GetAll()
            => _appDbContext.Statistics.Include(s => s.MatchPlayer);

        public Statistic GetById(int id)
            => _appDbContext.Statistics.Include(s => s.MatchPlayer).SingleOrDefault(s => s.Id == id);

        public async Task InsertAsync(Statistic Statistic)
        {
            _appDbContext.Statistics.Add(Statistic);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
