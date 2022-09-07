using SiinoCampanyShared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SiinoCampany.Services.Interfaces
{
    public interface IPerson
    {
        Task<Person> Person(string lastName, string firstName, DateTime birthDate);
    }
}
