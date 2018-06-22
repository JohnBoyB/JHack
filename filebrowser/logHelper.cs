/**
* 
 * The class logHelper provides the location of the logging message for the logging
 * 
 * GetLogger() 
        * @param string fileName
* 
**/   

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filebrowser
{
    class logHelper
    {
        public static log4net.ILog GetLogger([System.Runtime.CompilerServices.CallerFilePath] string filename = "")
        {
            return log4net.LogManager.GetLogger(filename);
        }
    }
}
