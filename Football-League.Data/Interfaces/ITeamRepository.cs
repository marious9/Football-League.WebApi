using Football_League.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.Data.Interfaces
{
    public interface ITeamRepository
    {
        Team GetById(int id);
        IEnumerable<Team> GetAll();
        Task InsertAsync(Team Team);
        Task EditAsync(Team Team);
        Task DeleteAsync(Team Team);
    }
}
