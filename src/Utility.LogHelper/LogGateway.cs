using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Utility.LogHelper
{
   public class LogGateway
    {
        private static ILogHelper _logHelper = null;

        public LogGateway(Type classType)
        {
            _logHelper = LogHelperFactory.GetLogHelper(classType,GetLoggerTypeFromConfig());
        }

        public void Trace(Exception ex)
        {
            _logHelper.Trace(ex);
        }

        public void Debug(Exception ex)
        {
            _logHelper.Debug(ex);
        }

        public void Info(string message)
        {
            _logHelper.Info(message);
        }

        public void Warn(string message)
        {
            _logHelper.Warn(message);
        }

        public void Error(Exception ex)
        {
            _logHelper.Error(ex);
        }

        public void Fatal(Exception ex)
        {
            _logHelper.Fatal(ex);
        }

        private string GetLoggerTypeFromConfig()
        {
            var type = ConfigurationManager.AppSettings["Log"];

            return type.ToString();
        }
    }
}
