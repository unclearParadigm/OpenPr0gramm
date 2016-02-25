using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace OpenPr0gramm
{
    /// <see cref="https://stackoverflow.com/a/23567113/785210"/>
    internal sealed class Timer : CancellationTokenSource
    {
        internal Timer(Action<object> callback, object state, int millisecondsDueTime, int millisecondsPeriod, bool waitForCallbackBeforeNextPeriod = false)
        {
            Debug.Assert(callback != null);
            Debug.Assert(millisecondsDueTime >= 0);
            Debug.Assert(millisecondsPeriod >= 0);

            Task.Delay(millisecondsDueTime, Token).ContinueWith(async (t, s) =>
            {
                var tuple = (Tuple<Action<object>, object>)s;

                while (!IsCancellationRequested)
                {
                    if (waitForCallbackBeforeNextPeriod)
                    {

                        tuple.Item1(tuple.Item2);
                    }
                    else
                    {
#pragma warning disable 4014
                        Task.Run(() => tuple.Item1(tuple.Item2)); // no wait
#pragma warning restore
                    }
                    await Task.Delay(millisecondsPeriod, Token).ConfigureAwait(false);
                }

            }, Tuple.Create(callback, state), CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously | TaskContinuationOptions.OnlyOnRanToCompletion, TaskScheduler.Default);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                Cancel();
            base.Dispose(disposing);
        }
    }

    /*
    internal sealed class Timer : CancellationTokenSource
    {
        public TimeSpan Interval { get; }
        private readonly TimerCallback _callback;
        public Timer(TimerCallback callback, TimeSpan interval)
        {
            Debug.Assert(callback != null);
            Interval = interval;
            _callback = callback;
        }

        public async Task Run()
        {
            while (!IsCancellationRequested)
            {
                _callback?.Invoke(Token);
                await Task.Delay(Interval, Token).ConfigureAwait(false);
            }
        }
    }
    public delegate void TimerCallback(CancellationToken token);
    */
}
