using System;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using System.Threading;

namespace TransitApp.Core
{
    internal delegate void TimerCallback(object state);

    internal sealed class CoolTimer : CancellationTokenSource, IDisposable
    {
        internal CoolTimer(TimerCallback callback, object state, int dueTime, int period = 0)
        {
            //			Contract.Assert(period == -1, "This stub implementation only supports dueTime.");
            Task.Delay(dueTime, Token).ContinueWith((t, s) =>
                {
                    
                    var tuple = (Tuple<TimerCallback, object>)s;
                    tuple.Item1(tuple.Item2);

                }, Tuple.Create(callback, state), CancellationToken.None,
                TaskContinuationOptions.ExecuteSynchronously | TaskContinuationOptions.OnlyOnRanToCompletion,
                TaskScheduler.Default);
        }

        public new void Dispose() { base.Cancel(); }
    }
}

