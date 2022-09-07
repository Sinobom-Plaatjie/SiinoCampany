using SiinoCampanyShared.Models;

namespace SinoCampanyApi.Data
{
    public class DbInitializer
    {
        private readonly SinoCampanyContext _context;

        public DbInitializer(SinoCampanyContext context)
        {
            _context = context;
        }
        public void Run()
        {
            if (!_context.Persons.Any())
            {

                var person = new Person();
                person.LastName = "Plaatjie";
                person.FirstName = "Sinobom"; 
                person.BirthDate = new DateTime(2022, 1, 1);
               
               
                var employee = new Employee();
                employee.EmployeeNum = "324";
                employee.EmployedDate = new DateTime(202, 12, 1);
                employee.Terminated = new DateTime(2002, 9, 3); ;
                employee.Person = new Person();

                _context.Persons.Add(person);
                _context.Employees.Add(employee);
                _context.SaveChanges();


            }
        }
    }
}
