using Football_League.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.Data.Interfaces
{
    public interface IMatchRepository
    {
        Match GetById(int id);
        IEnumerable<Match> GetAll();
        Task InsertAsync(Match Match);
        Task EditAsync(Match Match);
        Task DeleteAsync(Match Match);
    }
}
