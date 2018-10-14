using Football_League.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.Data.Interfaces
{
    public interface IMatchPlayerRepository
    {
        Task<MatchPlayer> GetByIdAsync(int matchId, int playerId);
        Task<IEnumerable<MatchPlayer>> GetAllAsync();
        Task InsertAsync(MatchPlayer MatchPlayer);
        Task EditAsync(MatchPlayer MatchPlayer);
        Task DeleteAsync(MatchPlayer MatchPlayer);
    }
}
