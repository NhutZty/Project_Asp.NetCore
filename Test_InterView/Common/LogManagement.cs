using log4net;
using System.IO;
using System.Reflection;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using Microsoft.Extensions.Logging.Log4Net.AspNetCore.Extensions;

namespace Test_InterView.Common
{
    #region LogManagement
    /// <summary>
    /// LogManagement Class
    /// </summary>
    public class LogManagement
    {
        /// <summary>
        /// Log
        /// </summary>
        private static readonly ILog _log = LogManager.GetLogger(typeof(LogManagement));

        #region WriteLogToFile
        /// <summary>
        /// WriteLogToFile
        /// </summary>
        /// <param name="message">Used to output the application supplied message associated with the logging event. </param>
        public static void WriteLogToFile(string message)
        {
            LoadConfiguration();
            // Writing log
            _log.Trace(message, null);
        }
        #endregion

        #region LoadConfiguration
        /// <summary>
        /// LoadConfiguration
        /// </summary>
        private static void LoadConfiguration()
        {
            FileInfo fileInfo = new FileInfo(Const.LOG_CONFIG_FILE);
            ILoggerRepository logRepo = LogManager.CreateRepository(
                Assembly.GetEntryAssembly(), typeof(Hierarchy));
            // Load and read file log4Net.config
            log4net.Config.XmlConfigurator.Configure(logRepo, fileInfo);
        }
        #endregion
    }
    #endregion
}
