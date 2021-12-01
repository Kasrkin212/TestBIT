using Chargily.Helpers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TestBIT.Data;
using TestBIT.View;
using TestBIT.Views;

namespace TestBIT.ViewModels
{
    public class CityViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        private RelayCommand _streetTableCommand;
        private DataView _dataTable = GetAllData.GetCityTable().DefaultView;
        public DataView DataTable
        {
            get
            {
                return _dataTable;
            }

            set
            {
                if (_dataTable == value)
                {
                    return;
                }

                _dataTable = value;
                RaisePropertyChanged();
            }
        }
        public RelayCommand StreetTableCommand
        {
            get
            {
                return _streetTableCommand
                    ?? (_streetTableCommand = new RelayCommand(
                    () =>
                    {

                        _navigationService.NavigateTo("StreetTable");
                    }));
            }
        }
        public CityViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
