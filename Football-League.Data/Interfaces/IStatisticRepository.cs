using Football_League.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.Data.Interfaces
{
    public interface IStatisticRepository
    {
        Task<Statistic> GetByIdAsync(int id);
        Task<IEnumerable<Statistic>> GetAllAsync();
        Task InsertAsync(Statistic Statistic);
        Task EditAsync(Statistic Statistic);
        Task DeleteAsync(Statistic Statistic);
    }
}
