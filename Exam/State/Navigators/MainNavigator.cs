using Exam.ViewModels;
using System;

namespace Exam.State.Navigators
{
    internal class MainNavigator : INavigator
    {
        private ViewModelBase? _viewModel;
        public ViewModelBase? CurrentViewModel { get => _viewModel; 
            set 
            {
                if (value == null) return;
                _viewModel = value;
                Navigated?.Invoke(_viewModel!);
            } 
        }

        public event Action<ViewModelBase>? Navigated;
    }
}
