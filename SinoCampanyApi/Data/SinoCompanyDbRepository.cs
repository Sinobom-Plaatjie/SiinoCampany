using Microsoft.EntityFrameworkCore;
using SiinoCampanyShared.Models;
using SinoCampanyApi.Interfaces;


namespace SinoCampanyApi.Data
{
    public class SinoCompanyDbRepository : ISinoCampanyDbRepository
    {
        private SinoCampanyContext _SinoCampanyContext;

        public SinoCompanyDbRepository(SinoCampanyContext SinoCampanyContext)
        {
            _SinoCampanyContext = SinoCampanyContext;
        }

        #region Person

        public Person CreateNewPerson(Person person)
        {
            _SinoCampanyContext.Persons.Add(person);
            _SinoCampanyContext.SaveChanges();

            return person;
        }

        public bool DoesPersonExistById(int id)
        {
            return _SinoCampanyContext.Persons.Any(person => person.PersonId == id);
        }

        public Person GetPersonById(int id, bool fullFetch = true)
        {
            if (fullFetch)
            {
                var person = _SinoCampanyContext.Persons.Where(x => x.PersonId == id).FirstOrDefault();
                return person;
            }
            else
            {
                var person = _SinoCampanyContext.Persons.Where(x => x.PersonId == id).FirstOrDefault();
                return person;
            }
        }
        #endregion

        #region Employee
       
        public Employee CreateNewEmployee(Employee employee)
        {
            _SinoCampanyContext.Employees.Add(employee);
            _SinoCampanyContext.SaveChanges();

            return employee;
        }


        public IList<Employee> GetLEmployeesByPersonId(int personId)
        {
            var allemployees = _SinoCampanyContext.Employees.Where(x => x.PersonId == personId).ToList();
            return allemployees;

        }

        public Employee GetEmployeeById(int employeeId)
        {
            var allemployees = _SinoCampanyContext.Employees.Where(x => x.EmployeeId == employeeId).FirstOrDefault();
            return allemployees;

        }

        #endregion

    }
}
