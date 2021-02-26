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
    public class TimerViewModel : ViewModelBase
    {
        
        private int _duration;
        private readonly TimerStore _timerStore;

        public int Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                _duration = value;
                OnPropertyChanged(nameof(_duration));
            }
        }

        public double RemainingSeconds => _timerStore.RemainingSeconds;

        public ICommand StartCommand 
        { 
            get; 
        }
        public TimerViewModel(TimerStore timerStore)
        {
            _timerStore = timerStore;
            StartCommand = new StartCommand(this, _timerStore);
            _timerStore.RemainingSecondsChanged += _timerStore_RemainingSecondsChanged;
        }

        private void _timerStore_RemainingSecondsChanged()
        {
            OnPropertyChanged(nameof(RemainingSeconds));
        }
    }
}
