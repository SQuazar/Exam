using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.ViewModels
{
    internal abstract class ViewModelBase : ObservableObject
    {
        public delegate TModel CreateViewModel<out TModel>() where TModel : ViewModelBase;
        public virtual void Dispose() { }
    }
}
