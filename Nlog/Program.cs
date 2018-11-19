using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nlog;
using NLog;
using System.Threading;

namespace Nlog
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            int a = 0;
            for(; ; )
            {
                logger.Log(LogLevel.Trace, "This is NO.{0} log message", a++);
                logger.Log(LogLevel.Debug, "This is NO.{0} log message", a++);
                logger.Log(LogLevel.Info, "This is NO.{0} log message", a++);
                logger.Log(LogLevel.Error, "This is NO.{0} log message", a++);
                logger.Log(LogLevel.Fatal, "This is NO.{0} log message", a++);
                logger.Log(LogLevel.Warn, "This is NO.{0} log message", a++);
                Thread.Sleep(1000);
            }
        }
    }
}
