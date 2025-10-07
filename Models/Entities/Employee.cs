namespace TestApi.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool? IsMarried { get; set; }
        public decimal Salary { get; set; }
        // foreign key
        public Guid? OfficeId { get; set; }
        // Navigation property (each employee belongs to one office)
        public Office? Office { get; set; }
    }
}