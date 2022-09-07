using SiinoCampany.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SiinoCampany.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonPage : ContentPage
    {
        public PersonViewModel personVM = new PersonViewModel();
        public PersonPage()
        {
            InitializeComponent();
            personVM = new PersonViewModel();

            MessagingCenter.Subscribe<PersonViewModel, string>(this, "Alert", (sender, lastName) => {
                DisplayAlert("", lastName, "ok");
            });
            this.BindingContext = personVM;
        }

        private void Add(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EmployeePage());
        }

        private void SKIP(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}