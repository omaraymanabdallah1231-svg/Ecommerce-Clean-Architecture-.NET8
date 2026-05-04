using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.application.servies.interfacee.Logging;
using Microsoft.Extensions.Logging;
using Serilog.Core;

namespace ecomerce.infrsutractor.servies
{
   public class serilogloginadapter<T> : IAppLogger<T>
    {
        ILogger<T> logger;
        public serilogloginadapter(ILogger<T> _logger)
        {
            logger=_logger;
        }
        public void LogErrors(Exception ex, string message) => logger.LogError(ex, message);

        public void LogInFormation(string message) => logger.LogInformation(message);

        public void logWanning(string message) => logger.LogWarning(message);
       
    }
}
