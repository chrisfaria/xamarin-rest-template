namespace xTemplate.Mobile.Models
{
    public class AuthenticationResponse
    {
        public AuthenticationResponse()
        {
            User = new User();
        }

        public bool IsAuthenticated { get; set; }
        public User User { get; set; }
    }
}
