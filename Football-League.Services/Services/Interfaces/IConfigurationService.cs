using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Services.Services.Interfaces
{
    public interface IConfigurationService
    {
        string GetValue(string key);
    }
}
