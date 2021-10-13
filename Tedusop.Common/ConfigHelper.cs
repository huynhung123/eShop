using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedusop.Common
{
    public class ConfigHelper
    {
        public static String GetByKey(String Key )
        {
            return ConfigurationManager.AppSettings[Key].ToString();
        }
    }
}
