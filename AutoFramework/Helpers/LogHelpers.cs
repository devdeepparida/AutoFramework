using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFramework.Helpers
{
    public class LogHelpers
    {
        //Global variable 
        private static string _logfilename = String.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        private static StreamWriter _streamWriter = null;

        //create a file which can store the log information.
        public static void CeateLogFile() {
            string dir = @"D:\log\";
            if (Directory.Exists(dir))
            {
                _streamWriter = File.AppendText(dir + _logfilename + ".log");
            }
            else {
                Directory.CreateDirectory(dir);
                _streamWriter = File.AppendText(dir + _logfilename + ".log");
            }
        }

        public static void WriteLog(string logMsg) {
            _streamWriter.Write("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _streamWriter.Write("   {0}", logMsg);
            _streamWriter.WriteLine();
            _streamWriter.Flush();

        }

    }
   
}
