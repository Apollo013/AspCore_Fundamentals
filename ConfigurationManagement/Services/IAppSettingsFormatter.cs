using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationManagement.Services
{
    public interface IAppSettingsFormatter
    {
        string Format(object input);
    }
}
