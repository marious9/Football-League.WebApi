using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Services.Services
{
    public static class ServiceErrors
    {
        public const string LEAGUE_ALREADY_EXISTS = "Liga o podanej nazwie już istnieje.";
        public const string LEAGUE_DOESNT_EXIST = "Liga nie istnieje.";

        public const string USER_NAME_ALREADY_EXISTS = "Użytkownik o podanej nazwie już istnieje.";
        public const string USER_EMAIL_ALREADY_EXISTS = "Użytkownik o podanym Email'u już istnieje.";
        public const string USER_DOESNT_EXIST = "Użytkownik o podanej nazwie nie istnieje.";
        public const string USER_INVALID_LOGIN_OR_PASSWORD = "Błędny login lub hasło.";
    }
}
