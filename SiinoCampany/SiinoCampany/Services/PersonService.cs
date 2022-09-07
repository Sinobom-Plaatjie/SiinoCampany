using Newtonsoft.Json;
using SiinoCampany.Services.Interfaces;
using SiinoCampanyShared.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SiinoCampany.Services
{
    
        public class PersonService
        {
            static PersonService _instance;

            public static PersonService Instance =>
                _instance ?? (_instance = new PersonService());

            private HttpClient _httpClient;

            public PersonService()
            {
                IHttpNativeHandler service = DependencyService.Get<IHttpNativeHandler>();
                _httpClient = new HttpClient(service.GetHttpClientHandler());
            }

            public async Task<Person> Person(string lastName, string firstName, DateTime birthDate)
            {
                var uri = new Uri(AppConfigurationService.Instance.SinoCampanyServerUrl + "api/Person");

                try
                {
                    var request = new Person() { LastName = lastName, FirstName = firstName, BirthDate = birthDate};

                    var requestJson = JsonConvert.SerializeObject(request);
                    var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                    var response = await _httpClient.PostAsync(uri, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var contentResponse = await response.Content.ReadAsStringAsync();

                        var valueResponse = JsonConvert.DeserializeObject<Person>(contentResponse);

                        return valueResponse;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(@"\tERROR {0}", ex.Message);
                }

                return null;
            }
        }
    
}
