using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xTemplate.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            //this.BindingContext = new LoginViewModel();
        }
    }
}
