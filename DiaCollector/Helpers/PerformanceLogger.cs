using System;
using System.Diagnostics;

namespace DiaCollector.Helpers
{
    [DebuggerStepThrough]
    public class PerformanceLogger : IDisposable
    {
        private static readonly log4net.ILog Logging = Zeta.Common.Logger.GetLoggerInstanceForType();
        private readonly string _blockName;
        private readonly Stopwatch _stopwatch;
        private bool _isDisposed;

        public PerformanceLogger(string blockName)
        {
            _blockName = blockName;
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (_isDisposed)
                return;

            _isDisposed = true;
            _stopwatch.Stop();
            
            LoggerIt.Debug("[Performance] Execution of {0} took {1:00.00}ms.", _blockName, _stopwatch.Elapsed.TotalMilliseconds);
            GC.SuppressFinalize(this);
        }

        #endregion

        ~PerformanceLogger()
        {
            Dispose();
        }
    }
}
