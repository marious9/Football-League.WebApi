﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Services.Services
{
    public static class ServiceErrors
    {
        public const string MATCH_TEAMS_IDS_CANT_BE_EQUAL = "Id drużyn muszą być różne.";
        public const string MATCH_TEAMS_ARENT_IN_THE_SAME_LEAGUE = "Drużyny nie grają w tej samej lidze.";

        public const string STH_WENT_WRONG = "Coś poszło nie tak.";

        public const string LEAGUE_ALREADY_EXISTS = "Liga o podanej nazwie już istnieje.";
        public const string LEAGUE_DOESNT_EXIST = "Liga nie istnieje.";

        public const string USER_NAME_ALREADY_EXISTS = "Użytkownik o podanej nazwie już istnieje.";
        public const string USER_EMAIL_ALREADY_EXISTS = "Użytkownik o podanym Email'u już istnieje.";
        public const string USER_DOESNT_EXIST = "Użytkownik o podanej nazwie nie istnieje.";
        public const string USER_INVALID_LOGIN_OR_PASSWORD = "Błędny login lub hasło.";

        public const string TEAM_WITH_THAT_NAME_ALREADY_EXISTS = "Drużyna o takiej nazwie już istnieje.";
        public const string TEAM_DOESNT_EXIST = "Drużyna nie istnieje.";

        public const string PLAYER_DOESNT_EXIST = "Zawodnik nie istnieje.";
    }
}
