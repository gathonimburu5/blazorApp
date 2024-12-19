using Blazored.Toast.Services;
using BlazorSite.Models;
using BlazorSite.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorSite.Components.Pages.Employees
{
    public partial class EditEmployee : ComponentBase
    {
        [Parameter]
        public int empId { get; set; }
        public Employee employeeRecords { get; set; }
        [Inject]
        public IEmployeeInterface employeeService { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        public IToastService toastService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            employeeRecords = await employeeService.GetEmployeePerId(empId);
        }

        private async Task UpdateEmployeeDetails()
        {
            var result = await employeeService.UpdateEmployeeRecords(employeeRecords, empId);
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
