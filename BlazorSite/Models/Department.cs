using System.ComponentModel.DataAnnotations;

namespace BlazorSite.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DepartmentHead { get; set; }
        public string AddressLocation { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public int Codes { get; set; }
        public string Message { get; set; }
    }

    public class DepartmentData
    {
        public virtual List<Department> DepartmentsRecords { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
