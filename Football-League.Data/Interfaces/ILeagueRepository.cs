using Football_League.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.Data.Interfaces
{
    public interface ILeagueRepository
    {
        Task<League> GetByIdAsync(int id);
        Task<IEnumerable<League>> GetAllAsync();
        Task InsertAsync(League League);
        Task EditAsync(League League);
        Task DeleteAsync(League League);
    }
}
