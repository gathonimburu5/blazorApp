using BlazorSite.Models;
using Newtonsoft.Json;
using System.Text;

namespace BlazorSite.Services
{
    public interface IDepertmentInterface
    {
        Task<List<Department>> getDepartmentRecords();
        Task<Department> createDepartmentRecord(Department department);
        Task<Department> getDepartmentRecordsPerId(int id);
        Task<Department> updateDepartmentRecord(Department department, int id);
        Task<Department> deleteDepartmentRecord(int id);
    }

    public class DepartmentService : IDepertmentInterface
    {
        private readonly IHttpClient httpService;
        public DepartmentService(IHttpClient httpService)
        {
            this.httpService = httpService;
        }

        public async Task<Department> createDepartmentRecord(Department department)
        {
            Department employeeData = new Department();
            var client = httpService.CreateHttpClient();

            var jsonStrings = JsonConvert.SerializeObject(department);
            var httpContent = new StringContent(jsonStrings, Encoding.UTF8, "application/json");
            var responseTask = client.PostAsync("Department/CreateDepartment", httpContent);

            responseTask.Wait();
            var result = responseTask.Result;
            int statusCode = (int)result.StatusCode;

            if (result.IsSuccessStatusCode)
            {
                var body = result.Content.ReadAsStringAsync().Result;
                Department responseObject = JsonConvert.DeserializeAnonymousType(body, employeeData);
                responseObject.Codes = (int)result.StatusCode;
                return await Task.FromResult(responseObject);
            }
            else if ((int)result.StatusCode == 400)
            {
                var body = result.Content.ReadAsStringAsync().Result;
                Department responseData = new Department { Codes = (int)result.StatusCode, Message = body };
                return await Task.FromResult(responseData);
            }
            else
            {
                //check if response data is empty
                var body = result.Content.ReadAsStringAsync().Result;
                Department responseData = JsonConvert.DeserializeAnonymousType(body, employeeData);
                responseData.Codes = (int)result.StatusCode;
                return await Task.FromResult(responseData);
            }
        }

        public async Task<Department> deleteDepartmentRecord(int id)
        {
            Department employeeData = new Department();
            var client = httpService.CreateHttpClient();
            var responseTask = client.DeleteAsync("Department/DeleteDepartmentDetails?id=" + id);

            responseTask.Wait();
            var result = responseTask.Result;
            int statusCode = (int)result.StatusCode;
            if (result.IsSuccessStatusCode)
            {
                var body = result.Content.ReadAsStringAsync().Result;
                Department responseObject = JsonConvert.DeserializeAnonymousType(body, employeeData);
                responseObject.Codes = (int)result.StatusCode;
                return await Task.FromResult(responseObject);
            }
            else if ((int)result.StatusCode == 400)
            {
                var body = result.Content.ReadAsStringAsync().Result;
                Department responseData = new Department { Codes = (int)result.StatusCode, Message = body };
                return await Task.FromResult(responseData);
            }
            else
            {
                //check if response data is empty
                var body = result.Content.ReadAsStringAsync().Result;
                Department responseData = JsonConvert.DeserializeAnonymousType(body, employeeData);
                responseData.Codes = (int)result.StatusCode;
                return await Task.FromResult(responseData);
            }
        }

        public Task<List<Department>> getDepartmentRecords()
        {
            List<Department> res = new List<Department>();
            var client = httpService.CreateHttpClient();
            var responseTask = client.GetAsync("Department/GetDepartmentDetail");
            responseTask.Wait();
            var result = responseTask.Result;
            int statusCode = (int)result.StatusCode;
            if (result.IsSuccessStatusCode)
            {
                var body = result.Content.ReadAsStringAsync().Result;
                var responseData = JsonConvert.DeserializeAnonymousType(body, res);
                var response = Task.FromResult(responseData);
                return response;
            }
            return Task.FromResult(res);
        }

        public Task<Department> getDepartmentRecordsPerId(int id)
        {
            Department res = new Department();
            var client = httpService.CreateHttpClient();
            var responseTask = client.GetAsync("Department/GetDepartmentPerId?id=" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            int statusCode = (int)result.StatusCode;
            //CHECK STATUS CODE
            if (result.IsSuccessStatusCode)
            {
                var body = result.Content.ReadAsStringAsync().Result;
                var responseData = JsonConvert.DeserializeAnonymousType(body, res);
                responseData.Codes = statusCode;
                var response = Task.FromResult(responseData);
                return response;
            }
            return Task.FromResult(res);
        }

        public async Task<Department> updateDepartmentRecord(Department department, int id)
        {
            Department employeeData = new Department();
            var client = httpService.CreateHttpClient();
            var jsonStrings = JsonConvert.SerializeObject(department);
            var httpContent = new StringContent(jsonStrings, Encoding.UTF8, "application/json");
            var responseTask = client.PutAsync("Department/EditDepartmentDetails?id=" + id, httpContent);

            responseTask.Wait();
            var result = responseTask.Result;
            int statusCode = (int)result.StatusCode;
            if (result.IsSuccessStatusCode)
            {
                var body = result.Content.ReadAsStringAsync().Result;
                Department responseObject = JsonConvert.DeserializeAnonymousType(body, employeeData);
                responseObject.Codes = (int)result.StatusCode;
                return await Task.FromResult(responseObject);
            }
            else if ((int)result.StatusCode == 400)
            {
                var body = result.Content.ReadAsStringAsync().Result;
                Department responseData = new Department { Codes = (int)result.StatusCode, Message = body };
                return await Task.FromResult(responseData);
            }
            else
            {
                //check if response data is empty
                var body = result.Content.ReadAsStringAsync().Result;
                Department responseData = JsonConvert.DeserializeAnonymousType(body, employeeData);
                responseData.Codes = (int)result.StatusCode;
                return await Task.FromResult(responseData);
            }
        }
    }
}
