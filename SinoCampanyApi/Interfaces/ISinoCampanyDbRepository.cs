
using SiinoCampanyShared.Models;

namespace SinoCampanyApi.Interfaces
{
    public interface ISinoCampanyDbRepository
    {

        Employee CreateNewEmployee(Employee employee);
        Person CreateNewPerson(Person person);

        Employee GetEmployeeById(int employeeId);

        Person GetPersonById(int id, bool fullFetch = true);
    }
}
