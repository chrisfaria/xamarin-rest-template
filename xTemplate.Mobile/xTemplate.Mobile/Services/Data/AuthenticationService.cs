using System;
using System.Threading.Tasks;
using xTemplate.Mobile.Contracts.Services.Data;
using xTemplate.Mobile.Models;

namespace xTemplate.Mobile.Services.Data
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationService()
        {
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

                System.Threading.Thread.Sleep(2000);

                return authenticationResponse;
            });
        }

        public bool IsUserAuthenticated()
        {
            return true;
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
