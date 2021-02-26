
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PopUp.Stores
{
    public class TimerStore
    {
        private readonly Timer _timer;

        private DateTime _endTime;

        public double RemainingSeconds => TimeSpan.FromTicks(_endTime.Ticks).TotalSeconds - TimeSpan.FromTicks(DateTime.Now.Ticks).TotalSeconds;

        public event Action RemainingSecondsChanged;
        public bool IsRunning => RemainingSeconds > 0;

        public void Start(int durationInSeconds)
        {
            _timer.Start();
            _endTime = DateTime.Now.AddSeconds(durationInSeconds);

            OnRemainingSecondsChanged();
        }

        public TimerStore()
        {
            _timer = new Timer(1000);
            _timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            OnRemainingSecondsChanged();
        }

        private void OnRemainingSecondsChanged()
        {
            RemainingSecondsChanged?.Invoke();
        }

        
    }
}
