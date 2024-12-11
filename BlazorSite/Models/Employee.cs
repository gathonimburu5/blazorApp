namespace BlazorSite.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmailAddress { get; set; }
        public string EmployeeNumber { get; set; }
        public string Contact { get; set; }
        public DateTime? DOB { get; set; } = DateTime.UtcNow;
        public string EmployeeStatus { get; set; }
        public string EmployeeType { get; set; }
        public string Gender { get; set; }
        public string PostalAddress { get; set; }
        public string PhysicalAddress { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public int Code { get; set; }
        public string Message { get; set; }
    }

    public class EmployeeData
    {
        public virtual List<Employee> EmployeeResult { get; set; }
        public virtual Employee EmployeeRecord { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
