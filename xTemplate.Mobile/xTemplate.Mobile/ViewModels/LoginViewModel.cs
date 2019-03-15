using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using xTemplate.Mobile.Contracts.Services.Data;
using xTemplate.Mobile.Contracts.Services.General;
using xTemplate.Mobile.ViewModels.Base;
using Xamarin.Forms;

namespace xTemplate.Mobile.ViewModels
{
    public class LoginViewModel: ViewModelBase
    {
        private IAuthenticationService _authenticationService;
        private readonly ISettingsService _settingsService;

        private string _userName;
        private string _password;

        public LoginViewModel(ISettingsService settingsService, 
            INavigationService navigationService, 
            IAuthenticationService authenticationService,
            IDialogService dialogService)
            :base(navigationService, dialogService)
        {
            _settingsService = settingsService;
            _authenticationService = authenticationService;
        }

        public ICommand LoginCommand => new Command(OnLogin);

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
                //OnPropertyChanged(nameof(_userName));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
                //OnPropertyChanged(nameof(_password));
            }
        }

        private async void OnLogin(object obj)
        {
            var authenticationResponse = await _authenticationService.Authenticate(UserName, Password);

            if (authenticationResponse.IsAuthenticated)
            {
                // we store the Id to know if the user is already logged in to the application
                _settingsService.UserIdSetting = authenticationResponse.User.Id;
                _settingsService.UserNameSetting = authenticationResponse.User.FirstName;

                await _dialogService.ShowDialog(
                    "This username/password combination isn't known",
                    "Error logging you in",
                    "OK");

                await _navigationService.NavigateToAsync<MainViewModel>();
            }
        }
    }
}
