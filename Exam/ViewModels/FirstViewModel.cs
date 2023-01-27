using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Exam.Domain.Model;
using Exam.Domain.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Exam.ViewModels
{
    internal partial class FirstViewModel : ViewModelBase
    {
        private readonly IPharmacyService _pharmacyService;
        [ObservableProperty] private ObservableCollection<Pharmacy> _pharmacies;

        public ICommand LoadData => new AsyncRelayCommand(async _ =>
        {
            Pharmacies = new ObservableCollection<Pharmacy>(await _pharmacyService.GetAll()); 
        });

        public FirstViewModel(IPharmacyService pharmacyService) 
        {
            _pharmacyService = pharmacyService;
            LoadData.Execute(1);
        }
    }
}
