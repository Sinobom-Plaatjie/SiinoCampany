using SiinoCampany.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SiinoCampany
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PersonPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
