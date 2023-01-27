using Exam.State.Navigators;
using Exam.ViewModels;
using Exam.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Command
{
    internal class ChangeViewModelCommand : CommandBase
    {
        private readonly INavigator _navigator;
        private readonly ViewModelFactory _viewModelFactory;

        public ChangeViewModelCommand(INavigator navigator, ViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public override void Execute(object? parameter)
        {
            if (parameter is not ViewType type) return;
            ViewModelBase? model = _viewModelFactory.Create(type);
            if (model == null) return;
            _navigator.CurrentViewModel = model;
        }
    }
}
