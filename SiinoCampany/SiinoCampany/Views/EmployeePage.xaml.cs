using SiinoCampany.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SiinoCampany
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeePage : ContentPage
    {
        public EmployeeViewModel employeeVM = new EmployeeViewModel();
        public EmployeePage()
        {
            InitializeComponent();
            employeeVM = new EmployeeViewModel();

            MessagingCenter.Subscribe<EmployeeViewModel, string>(this, "Alert", (sender, employeeNum) => {
                DisplayAlert("", employeeNum, "ok");
            });
            this.BindingContext = employeeVM;
        }

        private void AddEmployee(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    
    }
}