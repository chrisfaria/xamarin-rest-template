using System.Threading.Tasks;
using xTemplate.Mobile.Contracts.Services.General;
using xTemplate.Mobile.ViewModels.Base;

namespace xTemplate.Mobile.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private MenuViewModel _menuViewModel;

        public MainViewModel(IConnectionService connectionService, INavigationService navigationService, 
            MenuViewModel menuViewModel, 
            IDialogService dialogService)
            :base(connectionService, navigationService, dialogService)
        {
            _menuViewModel = menuViewModel;
        }

        public MenuViewModel MenuViewModel
        {
            get => _menuViewModel;
            set
            {
                _menuViewModel = value;
                OnPropertyChanged();
            }
        }

        public override async Task InitializeAsync(object data)
        {
            await Task.WhenAll
            (
                _menuViewModel.InitializeAsync(data),
                _navigationService.NavigateToAsync<HomeViewModel>()
            );
        }
    }
}
