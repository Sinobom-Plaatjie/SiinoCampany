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
    public class EmployeeService
    {
        static EmployeeService _instance;

        public static EmployeeService Instance =>
            _instance ?? (_instance = new EmployeeService());

        private HttpClient _httpClient;

        public EmployeeService()
        {
            IHttpNativeHandler service = DependencyService.Get<IHttpNativeHandler>();
            _httpClient = new HttpClient(service.GetHttpClientHandler());
        }

        public async Task<Employee> Employee(int personId, string employeeNum, DateTime employedDate, DateTime terminated)
        {
            var uri = new Uri(AppConfigurationService.Instance.SinoCampanyServerUrl + "api/Employee");

            try
            {
                var request = new Employee() { EmployeeNum = employeeNum, EmployedDate = employedDate, Terminated = terminated};

                var requestJson = JsonConvert.SerializeObject(request);
                var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    var contentResponse = await response.Content.ReadAsStringAsync();

                    var valueResponse = JsonConvert.DeserializeObject<Employee>(contentResponse);

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

