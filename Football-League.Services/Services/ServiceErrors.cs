using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Services.Services
{
    public static class ServiceErrors
    {
        public const string STATISTIC_PLAYER_HAS_RED_CARD = "Zawodnik otrzymał czerwoną kartkę.";
        public const string STATISTIC_SCORE_IS_NOT_ALLOW_TO_ADD_GOAL_ACTION = "Wynik meczu nie pozwala dodać tej akcji.";
        public const string STATISTIC_INVALID_ACTION = "Podana akcja nie istnieje.";
        public const string STATISTIC_DOES_NOT_EXIST = "Nie znaleziono statystyki.";

        public const string MATCH_PLAYER_DOES_NOT_EXIST = "Zawodnik nie jest przypisany do tego meczu.";

        public const string MATCH_GIVEN_ROUND_IS_GREATER_THAN_MAX_ROUND = "Podana kolejka nie jest rozgrywana w tej lidze.";
        public const string MATCH_ONE_OF_TEAMS_ALREADY_PLAYS_MATCH_IN_GIVEN_ROUND = "Co najmniej jedna z drużyn gra już mecz w tej kolejce.";
        public const string MATCH_TEAMS_IDS_CANT_BE_EQUAL = "Id drużyn muszą być różne.";
        public const string MATCH_TEAMS_ARENT_IN_THE_SAME_LEAGUE = "Drużyny nie grają w tej samej lidze.";
        public const string MATCH_DOES_NOT_EXIST = "Mecz nie istnieje.";
        public const string MATCH_THERE_IS_NO_MATCHES_FROM_THAT_LEAGUE = "Nie znaleziono meczów dla tej ligii.";

        public const string STH_WENT_WRONG = "Coś poszło nie tak.";

        public const string LEAGUE_NOT_AVAILABLE_NUMBER_OF_TEAMS = "Nie wystarczająca liczba drużyn w lidze.";
        public const string LEAGUE_ALREADY_EXISTS = "Liga o podanej nazwie już istnieje.";
        public const string LEAGUE_DOESNT_EXIST = "Liga nie istnieje.";

        public const string USER_NAME_ALREADY_EXISTS = "Użytkownik o podanej nazwie już istnieje.";
        public const string USER_EMAIL_ALREADY_EXISTS = "Użytkownik o podanym Email'u już istnieje.";
        public const string USER_DOESNT_EXIST = "Użytkownik o podanej nazwie nie istnieje.";
        public const string USER_INVALID_LOGIN_OR_PASSWORD = "Błędny login lub hasło.";

        public const string TEAM_WITH_THAT_NAME_ALREADY_EXISTS = "Drużyna o takiej nazwie już istnieje.";
        public const string TEAM_DOESNT_EXIST = "Drużyna nie istnieje.";
        public const string TEAM_THER_IS_ENOUGH_TEAMS_IN_THAT_LEAGUE = "Liga zawiera ustaloną wcześniej liczebność.";

        public const string PLAYER_DOESNT_EXIST = "Zawodnik nie istnieje.";
    }
}
