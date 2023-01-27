using Exam.Command;
using Exam.Control;
using Exam.State.Navigators;
using Exam.ViewModels.Factories;
using System.Windows.Input;

namespace Exam.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        public ViewModelBase? CurrentViewModel => _navigator.CurrentViewModel;

        public ICommand ChangeViewModel { get; }

        public MainViewModel(INavigator navigator, ViewModelFactory modelFactory)
        {
            _navigator = navigator!;
            _navigator.Navigated += Navigated;
            ChangeViewModel = new ChangeViewModelCommand(_navigator, modelFactory);
            ChangeViewModel.Execute(ViewType.Home);
        }

        private void Navigated(ViewModelBase? to)
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public override void Dispose()
        {
            _navigator.Navigated -= Navigated;
        }
    }
}
