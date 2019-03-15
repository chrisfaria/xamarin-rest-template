using System;
using System.Threading.Tasks;
using xTemplate.Mobile.Contracts.Services.Data;
using xTemplate.Mobile.Contracts.Services.General;
using xTemplate.Mobile.Models;

namespace xTemplate.Mobile.Services.Data
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ISettingsService _settingsService;
        public AuthenticationService(ISettingsService settingsService)
        {
            _settingsService = settingsService;

        }

        public async Task<AuthenticationResponse> Authenticate(string userName, string password)
        {
            AuthenticationRequest authenticationRequest = new AuthenticationRequest()
            {
                UserName = userName,
                Password = password
            };



            return await Task.Factory.StartNew(() =>
            {
                AuthenticationResponse authenticationResponse = new AuthenticationResponse();
                authenticationResponse.IsAuthenticated = true;
                authenticationResponse.User.UserName = userName;
                authenticationResponse.User.FirstName = "Chris";

                System.Threading.Thread.Sleep(2000);

                return authenticationResponse;
            });
        }

        public bool IsUserAuthenticated()
        {
            return !string.IsNullOrEmpty(_settingsService.UserIdSetting);
        }

        public async Task<AuthenticationResponse> Register(string firstName, string lastName, string email, string userName, string password)
        {
            AuthenticationRequest authenticationRequest = new AuthenticationRequest()
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
                Password = password
            };

            throw new NotImplementedException();
        }
    }
}
