using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.LogHelper
{
    interface ILogHelper
    {
        void Trace(Exception ex);
        void Debug(Exception ex);
        void Info(string message);
        void Warn(string message);
        void Error(Exception ex);
        void Fatal(Exception ex);

    }
}
