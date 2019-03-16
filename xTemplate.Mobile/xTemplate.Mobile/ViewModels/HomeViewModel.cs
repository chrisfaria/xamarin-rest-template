using xTemplate.Mobile.Contracts.Services.Data;
using xTemplate.Mobile.Contracts.Services.General;
using xTemplate.Mobile.Models;
using xTemplate.Mobile.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using xTemplate.Mobile.Constants;
//using xTemplate.Mobile.Extensions;
using Xamarin.Forms;

namespace xTemplate.Mobile.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {

        public HomeViewModel(IConnectionService connectionService, INavigationService navigationService, 
            IDialogService dialogService)
            : base(connectionService, navigationService, dialogService)
        {

        }

    }
}