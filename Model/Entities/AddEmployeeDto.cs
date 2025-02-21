namespace EmployeeAdminPortal.Model.Entities
{
    public class AddEmployeeDto
    {
        public required string Name { get; set; }
        //public string Name { get; set; }
        //if we use required its a mandatory field

        public required string Email { get; set; }

        public string? Phone { get; set; }
        //if we want phone as optinal means even NULL can be accepted
        //then we need to use ? after the datatype...then null value will be accepted

        public decimal Salary { get; set; }
    }
}
