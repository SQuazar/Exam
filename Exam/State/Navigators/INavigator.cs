using Exam.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.State.Navigators
{
    internal interface INavigator
    {
        ViewModelBase? CurrentViewModel { get; set; }
        event Action<ViewModelBase> Navigated;
    }
}
