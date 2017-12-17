using System;
using System.Collections.Generic;
using System.IO;

namespace SynchronizeIt
{
    public interface iLogger
    {
        void LogMessage(LogLevel logLevel, string message = null, Exception exception = null);
    }

    public enum LogLevel
    {
        Info,
        Error
    }

    public class Logger : iLogger
    {
        private log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void LogMessage(LogLevel logLevel, string message = null, Exception exception = null)
        {
            if (message == null)
            {
                throw new Exception("Message text cannot be null");
            }
            switch (logLevel)
            {
                case LogLevel.Error:
                    {
                        if (exception != null)
                        {
                            _logger.Error(message, exception);
                        }
                        else
                        {
                            _logger.Error(message);
                        }
                        break;
                    }
                case LogLevel.Info:
                default:
                    {
                        if (exception != null)
                        {
                            _logger.Info(message, exception);
                        }
                        else
                        {
                            _logger.Info(message);
                        }
                        break;
                    }
            }
        }
    }

    public class CustomLogger : iLogger
    {
        private string _logfileName = "SynchronizeIt.log";
        public void LogMessage(LogLevel logLevel, string message = null, Exception exception = null)
        {
            while (true)
            {
                try
                {
                    if (File.Exists(_logfileName))
                    {
                        FileInfo fil = new FileInfo(_logfileName);
                        if (fil.Length >= 10000000)
                            File.Delete(_logfileName);
                    }

                    lock (this)
                    {
                        using (StreamWriter file = new StreamWriter(_logfileName, true))
                        {
                            file.Write(DateTime.Now + ": ");
                            file.WriteLine(message);
                            return;
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}