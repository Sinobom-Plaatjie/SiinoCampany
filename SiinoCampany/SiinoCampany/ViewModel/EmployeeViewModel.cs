using SiinoCampany.Services;
using SiinoCampany.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SiinoCampany.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private IEmployee _employeeService;
        public event PropertyChangedEventHandler PropertyChanged;
        public int personId;
        public string employeeNum;
        public DateTime employedDate;
        public DateTime terminated;


        public int PersonId
        {
            get { return personId; }
            set
            {
                personId = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PersonId"));
            }
        }

        public string EmployeeNum
        {
            get { return employeeNum; }
            set
            {
                employeeNum = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EmployeeNum"));
            }
        }
        public DateTime EmployedDate
        {
            get { return employedDate; }
            set
            {
                employedDate = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EmployedDate"));
            }
        }
        public DateTime Terminated
        {
            get { return terminated; }
            set
            {
                terminated = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Terminated"));
            }
        }

        public ICommand SaveSubmitCommand { get; set; }
        public EmployeeViewModel()
        {
            SaveSubmitCommand = new Command(OnSubmitAsync);
        }
        public async void OnSubmitAsync()
        {

            if (IsValidated())
            {
                await SaveEmployee();

                await App.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
        }
        public bool IsValidated()
        {
            if (string.IsNullOrEmpty(EmployeeNum)
               && EmployedDate == default(DateTime))
            {
                MessagingCenter.Send(this, "Alert", "Please fill-up the form");
                return false;
            }


            return false;
        }
        public async Task SaveEmployee()
        {
            try
            {
                EmployeeService _employeeService = new EmployeeService();

                var user = await _employeeService.Employee(PersonId = this.PersonId, EmployeeNum = this.employeeNum, EmployedDate = this.EmployedDate, Terminated = this.Terminated);


                if (user != null)
                {
                    await App.Current.MainPage.Navigation.PushAsync(new MainPage());
                }

                else
                {
                    MessagingCenter.Send(this, "Alert", "Fill in all detils");
                }
            }
            catch { }


        }
    }
}

