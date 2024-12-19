using Blazored.Toast.Services;
using BlazorSite.Models;
using BlazorSite.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorSite.Components.Pages.Employees
{
    public partial class CreateEmployee
    {
        public Employee employeeRecords { get; set; } = new();
        [Inject]
        public IEmployeeInterface employeeService { get; set; }
        [Inject]
        public IToastService toastService { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }

        private async Task SaveEmployeeDetails()
        {
            var result = await employeeService.CreateEmployeeRecords(employeeRecords);
            if(result.Code == 200)
            {
                toastService.ShowSuccess(result.Message);
                navigationManager.NavigateTo("/employee");
            }
        }

        private void CancelCreation()
        {
            navigationManager.NavigateTo("/employee");
        }
    }
}
