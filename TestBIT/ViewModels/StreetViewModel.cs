using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBIT.Data;

namespace TestBIT.ViewModels
{
    public class StreetViewModel : ViewModelBase
    {
        public DataView DataTable { get; set; } = GetAllData.GetStreetTable().DefaultView;
    }
}
