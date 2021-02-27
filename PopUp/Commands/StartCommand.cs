using PopUp.Stores;
using PopUp.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopUp.Commands
{
    public class StartCommand : BaseCommand
    {
        private readonly TimerViewModel _viewModel;
        private readonly TimerStore _timerStore;

        public StartCommand(TimerViewModel viewModel, TimerStore timerStore)
        {
            _viewModel = viewModel;
            _timerStore = timerStore;
        }

        public override void Execute(object parameter)
        {
            _timerStore.Start(_viewModel.Duration);
        }
    }
}
