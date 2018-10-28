using Football_League.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.Data.Interfaces
{
    public interface ILeagueRepository
    {
        League GetById(int id);
        League GetByName(string name);
        IEnumerable<League> GetAll();
        Task InsertAsync(League League);
        Task EditAsync(League League);
        Task DeleteAsync(League League);
    }
}
