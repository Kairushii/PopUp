using PopUp.Commands;
using PopUp.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PopUp.Viewmodels
{
    public class TimerViewModel : ViewModelBase , IDisposable
    {
        private readonly TimerStore _timerStore;

        private int _duration;
        public int Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                _duration = value;
                OnPropertyChanged(nameof(Duration));
            }
        }

        public double RemainingSeconds => _timerStore.RemainingSeconds;

        public ICommand StartCommand { get; }

        public TimerViewModel(TimerStore timerStore)
        {
            _timerStore = timerStore;
            StartCommand = new StartCommand(this, _timerStore);

            _timerStore.RemainingSecondsChanged += TimerStore_RemainingSecondsChanged;
        }

        private void TimerStore_RemainingSecondsChanged()
        {
            OnPropertyChanged(nameof(RemainingSeconds));
        }

        public void Dispose()
        {
            _timerStore.RemainingSecondsChanged -= TimerStore_RemainingSecondsChanged;
        }
    }
}
