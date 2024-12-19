using Blazored.Toast.Services;
using BlazorSite.Models;
using BlazorSite.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorSite.Components.Pages.Employees
{
    public partial class IndexEmployee
    {
        public EmployeeData EmployeeList { get; set; }
        [Inject]
        public IEmployeeInterface employeeService { get; set; }
        public NavigationManager navManager { get; set; }
        public IToastService toastService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            EmployeeList = await employeeService.GetEmployeeRecords();
        }

        private void navigateToEditPage(int empId)
        {
            navManager.NavigateTo($"/employee/update/{empId}");
        }

        private async Task deleteEmployee(int empId)
        {
            var result = await employeeService.DeleteEmployeeRecords(empId);
            if(result.Code == 200)
            {
                toastService.ShowSuccess(result.Message);
                EmployeeList = await employeeService.GetEmployeeRecords();
            }
        }
    }
}
