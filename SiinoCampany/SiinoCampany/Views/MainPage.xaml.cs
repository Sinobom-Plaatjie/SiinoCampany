using SiinoCampany.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SiinoCampany
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new EmployeePage
            {
                //BindingContext = e.SelectedItem as Employee
            });
        }

        private async void AddedNewEmployer(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PersonPage());
        }
    }
}
