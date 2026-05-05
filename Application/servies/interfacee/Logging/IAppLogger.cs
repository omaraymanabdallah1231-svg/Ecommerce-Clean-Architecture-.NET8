using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.servies.interfacee.Logging
{
    public interface IAppLogger<T>
    {
        void LogInFormation(string message);
        void LogErrors(Exception ex,string message);
        void logWanning(string message);


    }
}
