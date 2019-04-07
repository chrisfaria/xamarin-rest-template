using xTemplate.Mobile.Contracts.Services.Data;
using xTemplate.Mobile.Contracts.Services.General;
using xTemplate.Mobile.Models;
using xTemplate.Mobile.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using xTemplate.Mobile.Constants;
using xTemplate.Mobile.Extensions;
using Xamarin.Forms;

namespace xTemplate.Mobile.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly ICatalogDataService _catalogDataService;

        private ObservableCollection<Item> _items;

        public HomeViewModel(IConnectionService connectionService, INavigationService navigationService, 
            IDialogService dialogService,
            ICatalogDataService catalogDataService)
            : base(connectionService, navigationService, dialogService)
        {
            _catalogDataService = catalogDataService;
        }


        public ObservableCollection<Item> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public override async Task InitializeAsync(object data)
         {
              IsBusy = true;

              Items = (await _catalogDataService.GetAllItemsAsync()).ToObservableCollection();

              IsBusy = false;
         }
    }
}