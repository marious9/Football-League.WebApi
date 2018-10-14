using Football_League.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.Data.Interfaces
{
    public interface IPlayerRepository
    {
        Task<Player> GetByIdAsync(int id);
        Task<IEnumerable<Player>> GetAllAsync();
        Task InsertAsync(Player Player);
        Task EditAsync(Player Player);
        Task DeleteAsync(Player Player);
    }
}
