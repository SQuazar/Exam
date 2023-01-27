using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    internal partial class Pharmacy : EntityBase
    {
        [ObservableProperty] private string _name = null!;
        [ObservableProperty] private string _address = null!;
        [ObservableProperty] private TimeSpan _startWorking = TimeSpan.MinValue;
        [ObservableProperty] private TimeSpan _endWorking = TimeSpan.MaxValue;
    }
}
