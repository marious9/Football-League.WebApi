using Football_League.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.Data.Interfaces
{
    public interface ITeamRepository
    {
        Task<Team> GetByIdAsync(int id);
        Task<IEnumerable<Team>> GetAllAsync();
        Task InsertAsync(Team Team);
        Task EditAsync(Team Team);
        Task DeleteAsync(Team Team);
    }
}
