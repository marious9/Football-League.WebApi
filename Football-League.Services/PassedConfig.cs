using Football_League.Data;
using Football_League.Data.Interfaces;
using Football_League.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Services
{
    public class PassedConfig
    {   
        public static void Config(IConfiguration configuration, IServiceCollection services)
        {
            var config = new StartUpConfig(configuration);
            config.PartOfConfigureServices(services);

            services.AddTransient<ILeagueRepository, LeagueRepository>();         
            services.AddTransient<IMatchRepository, MatchRepository>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<IStatisticRepository, StatisticRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<IMatchPlayerRepository, MatchPlayerRepository>();
        }
    }
}
