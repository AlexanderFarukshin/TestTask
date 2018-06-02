namespace Task.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}