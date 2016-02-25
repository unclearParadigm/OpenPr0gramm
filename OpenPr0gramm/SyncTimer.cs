using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace OpenPr0gramm
{
    class SyncTimer : IDisposable
    {
        public static TimeSpan LowestMeaningfulInterval { get; } = TimeSpan.FromMinutes(1);
        public static TimeSpan DefaultInterval { get; } = LowestMeaningfulInterval;

        public TimeSpan Interval { get; }
        public IPr0grammUserService UserService { get; }
        public int LastId { get; set; } = 0;

        public event EventHandler<SyncResponse> SyncCompleted;

        private Timer _timer;
        private readonly object _lockObj = new object();

        #region Ctors

        public SyncTimer(IPr0grammApiClient apiClient)
            : this(GetServiceFromClient(apiClient))
        { }
        public SyncTimer(IPr0grammUserService userService)
            : this(userService, DefaultInterval)
        { }
        public SyncTimer(IPr0grammApiClient apiClient, TimeSpan syncInterval)
            : this(GetServiceFromClient(apiClient), syncInterval)
        { }
        public SyncTimer(IPr0grammUserService userService, TimeSpan syncInterval)
        {
            if (userService == null)
                throw new ArgumentNullException(nameof(userService));
            UserService = userService;
            Interval = syncInterval < LowestMeaningfulInterval ? LowestMeaningfulInterval : syncInterval;
        }

        #endregion

        public void Start()
        {
            lock (_lockObj)
            {
                _timer?.Dispose();
                _timer = new Timer(async _ => await TimerCallback().ConfigureAwait(false) /* exception stuff. do not touch. */, null, 0, (int)Interval.TotalMilliseconds, true);
            }
        }

        public void Stop()
        {
            lock (_lockObj)
            {
                _timer?.Dispose();
            }
        }

        private async Task TimerCallback()
        {
            var res = await UserService.Sync(LastId).ConfigureAwait(false);
            Debug.Assert(res != null);
            LastId = res.LastId;
            SyncCompleted?.Invoke(this, res);
        }

        private static IPr0grammUserService GetServiceFromClient(IPr0grammApiClient client)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            return client.User;
        }

        #region IDisposable Support

        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                    _timer?.Dispose();
                disposedValue = true;
            }
        }
        public void Dispose() => Dispose(true);

        #endregion
    }
}
