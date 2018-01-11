using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.LogHelper
{
    class LogHelperFactory
    {
        public static ILogHelper GetLogHelper(Type classType, string loggerType)
        {
            ILogHelper LogHelper = null;

            var Instance = Activator.CreateInstance(Type.GetType(loggerType),classType);
            LogHelper = Instance as ILogHelper;

            return LogHelper;
        }
       
    }
}
