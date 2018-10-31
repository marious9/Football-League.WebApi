using Football_League.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.Data.Interfaces
{
    public interface IPlayerRepository
    {
        Player GetById(int id);
        IEnumerable<Player> GetAll();
        Task InsertAsync(Player Player);
        Task EditAsync(Player Player);
        Task DeleteAsync(Player Player);
    }
}
