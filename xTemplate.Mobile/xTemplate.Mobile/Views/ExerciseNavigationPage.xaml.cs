using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xTemplate.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExerciseNavigationPage : NavigationPage
    {
		public ExerciseNavigationPage ()
		{
			InitializeComponent ();
		}

        public ExerciseNavigationPage(Page root) : base(root)
        {
            InitializeComponent();
        }
    }
}