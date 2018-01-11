using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Utility.LogHelper
{
    class NLogHelper:ILogHelper
    {
        private static NLog.Logger _logger;
        public NLogHelper(Type type)
        {
            _logger = LogManager.GetLogger(type.FullName);
        }
         
        public void Trace(Exception ex)
        {
            _logger.Trace(ex, ex.Message);
        }

        public void Debug(Exception ex)
        {
            _logger.Debug(ex, ex.Message);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Warn(string message)
        {
            _logger.Warn(message);
        }

        public void Error(Exception ex)
        {
            _logger.Error(ex, ex.Message);
        }

        public void Fatal(Exception ex)
        {
            _logger.Fatal(ex, ex.Message);
        }
    }
}
