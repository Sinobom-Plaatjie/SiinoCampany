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
    public class PersonViewModel : INotifyPropertyChanged
    {
        private IPerson _personService;
        public event PropertyChangedEventHandler PropertyChanged;
        public string lastName;
        public string firstName;
        public DateTime birthDate;


        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LastName"));
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
            }
        }
        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                birthDate = value;
                PropertyChanged(this, new PropertyChangedEventArgs("BirthDate"));
            }
        }

        public ICommand SaveSubmitCommand { get; set; }
        public PersonViewModel()
        {
            SaveSubmitCommand = new Command(OnSubmitAsync);
        }
        public async void OnSubmitAsync()
        {

            if (IsValidated())
            {
                await SavePerson();

                await App.Current.MainPage.Navigation.PushAsync(new EmployeePage());
            }
        }
        public bool IsValidated()
        {
            if (string.IsNullOrEmpty(LastName)
               && string.IsNullOrEmpty(FirstName) && BirthDate == default(DateTime))
            {
                MessagingCenter.Send(this, "Alert", "Please fill-up the form");
                return false;
            }
          

            return false;
        }
        public async Task SavePerson()
        {
            try
            {
                PersonService _personService = new PersonService();

                var user = await _personService.Person(LastName = this.LastName, FirstName = this.FirstName, BirthDate = this.BirthDate);


                if (user != null)
                {
                    await App.Current.MainPage.Navigation.PushAsync(new EmployeePage());
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
