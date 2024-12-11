using BlazorSite.Models;
using Newtonsoft.Json;
using System.Text;

namespace BlazorSite.Services
{
    public interface IEmployeeInterface
    {
        Task<EmployeeData> GetEmployeeRecords();
        Task<Employee> CreateEmployeeRecords(Employee employee);
        Task<Employee> GetEmployeePerId(int id);
        Task<Employee> UpdateEmployeeRecords(Employee employee, int id);
        Task<Employee> DeleteEmployeeRecords(int id);
    }

    public class EmployeeService : IEmployeeInterface
    {
        private readonly IHttpClient clientService;
        public EmployeeService(IHttpClient clientService)
        {
            this.clientService = clientService;
        }

        public async Task<Employee> CreateEmployeeRecords(Employee employee)
        {
            Employee employeeData = new Employee();
            var client = clientService.CreateHttpClient();

            var jsonStrings = JsonConvert.SerializeObject(employee);
            var httpContent = new StringContent(jsonStrings, Encoding.UTF8, "application/json");
            var responseTask = client.PostAsync("Employee/CreateEmployee", httpContent);

            responseTask.Wait();
            var result = responseTask.Result;
            int statusCode = (int)result.StatusCode;

            if (result.IsSuccessStatusCode)
            {
                var body = result.Content.ReadAsStringAsync().Result;
                Employee responseObject = JsonConvert.DeserializeAnonymousType(body, employeeData);
                responseObject.Code = (int)result.StatusCode;
                return await Task.FromResult(responseObject);
            }
            else if ((int)result.StatusCode == 400)
            {
                var body = result.Content.ReadAsStringAsync().Result;
                Employee responseData = new Employee
                {
                    Code = (int)result.StatusCode,
                    Message = body
                };
                return await Task.FromResult(responseData);
            }
            else
            {
                //check if response data is empty
                var body = result.Content.ReadAsStringAsync().Result;
                Employee responseData = JsonConvert.DeserializeAnonymousType(body, employeeData);
                responseData.Code = (int)result.StatusCode;
                return await Task.FromResult(responseData);
            }
        }

        public Task<Employee> DeleteEmployeeRecords(int id)
        {
            Employee employee = new Employee();
            var client = clientService.CreateHttpClient();
            var responseTask = client.DeleteAsync("Employee/DeleteEmployeeRecord?id=" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            int statusCode = (int)result.StatusCode;
            //CHECK STATUS CODE
            if (result.IsSuccessStatusCode)
            {
                var body = result.Content.ReadAsStringAsync().Result;
                var responseData = JsonConvert.DeserializeAnonymousType(body, employee);
                responseData.Code = statusCode;
                var response = Task.FromResult(responseData);
                return response;
            }
            else
            {
                var body = result.Content.ReadAsStringAsync().Result;
                Employee responseData = new Employee
                {
                    Code = (int)result.StatusCode,
                    Message = body
                };
                return Task.FromResult(responseData);
            }
        }

        public Task<Employee> GetEmployeePerId(int id)
        {
            Employee res = new Employee();
            //client.BaseAddress = new Uri(BASE_URL);
            var client = clientService.CreateHttpClient();
            //HTTP GET
            var responseTask = client.GetAsync("Employee/GetEmployeeById?id=" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            int statusCode = (int)result.StatusCode;
            //CHECK STATUS CODE
            if (result.IsSuccessStatusCode)
            {
                var body = result.Content.ReadAsStringAsync().Result;
                var responseData = JsonConvert.DeserializeAnonymousType(body, res);
                responseData.Code = statusCode;
                var response = Task.FromResult(responseData);
                return response;
            }
            else
            {
                var body = result.Content.ReadAsStringAsync().Result;
                Employee responseData = new Employee
                {
                    Code = (int)result.StatusCode,
                    Message = body
                };
                return Task.FromResult(responseData);
            }
        }

        public Task<EmployeeData> GetEmployeeRecords()
        {
            EmployeeData res = new EmployeeData();
            //client.BaseAddress = new Uri(BASE_URL);
            var client = clientService.CreateHttpClient();
            //HTTP GET
            var responseTask = client.GetAsync("Employee/GetEmployeeRecord");
            responseTask.Wait();
            var result = responseTask.Result;
            int statusCode = (int)result.StatusCode;
            //CHECK STATUS CODE
            if (result.IsSuccessStatusCode)
            {
                var body = result.Content.ReadAsStringAsync().Result;
                var responseData = JsonConvert.DeserializeAnonymousType(body, res);
                responseData.Code = statusCode;
                var response = Task.FromResult(responseData);
                return response;
            }
            else
            {
                var body = result.Content.ReadAsStringAsync().Result;
                EmployeeData responseData = new EmployeeData
                {
                    Code = (int)result.StatusCode,
                    Message = body
                };
                return Task.FromResult(responseData);
            }
        }

        public async Task<Employee> UpdateEmployeeRecords(Employee employee, int id)
        {
            Employee employeeData = new Employee();
            var client = clientService.CreateHttpClient();

            var jsonString = JsonConvert.SerializeObject(employee);
            var httpContext = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var responseTask = client.PutAsync("Employee/EditEmployeeRecord?id=" + id, httpContext);

            responseTask.Wait();
            var result = responseTask.Result;
            int statusCode = (int)result.StatusCode;

            if (result.IsSuccessStatusCode)
            {
                var body = result.Content.ReadAsStringAsync().Result;
                Employee responseObject = JsonConvert.DeserializeAnonymousType(body, employeeData);
                responseObject.Code = (int)result.StatusCode;
                return await Task.FromResult(responseObject);
            }
            else if ((int)result.StatusCode == 400)
            {
                var body = result.Content.ReadAsStringAsync().Result;
                Employee responseData = new Employee
                {
                    Code = (int)result.StatusCode,
                    Message = body
                };
                return await Task.FromResult(responseData);
            }
            else
            {
                //check if response data is empty
                var body = result.Content.ReadAsStringAsync().Result;
                Employee responseData = JsonConvert.DeserializeAnonymousType(body, employeeData);
                responseData.Code = (int)result.StatusCode;
                return await Task.FromResult(responseData);
            }
        }
    }
}
