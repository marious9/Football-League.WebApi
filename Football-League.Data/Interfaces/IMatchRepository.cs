using Football_League.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.Data.Interfaces
{
    public interface IMatchRepository
    {
        Task<Match> GetByIdAsync(int id);
        Task<IEnumerable<Match>> GetAllAsync();
        Task InsertAsync(Match Match);
        Task EditAsync(Match Match);
        Task DeleteAsync(Match Match);
    }
}
