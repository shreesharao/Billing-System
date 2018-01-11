using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.LogHelper;

namespace Utility.DatabaseHelper
{
    class DBHelperFactory
    {
        private static IDBhelper _iDBhelper = null;



        public static IDBhelper GetDBHelper(string type)
        {
            try
            {
                var Instance = Activator.CreateInstance(Type.GetType(type));
                _iDBhelper = Instance as IDBhelper;
            }
            catch (Exception ex)
            {
               throw new Exception(string.Format("{0:1}","Could not create instance of type",type),ex);
            }
            

            return _iDBhelper;
        }
    }
}
