using Football_League.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.Data.Interfaces
{
    public interface IMatchPlayerRepository
    {
        MatchPlayer GetById(int matchId, int playerId);
        IEnumerable<MatchPlayer> GetAll();
        Task InsertAsync(MatchPlayer MatchPlayer);
        Task EditAsync(MatchPlayer MatchPlayer);
        Task DeleteAsync(MatchPlayer MatchPlayer);
    }
}
