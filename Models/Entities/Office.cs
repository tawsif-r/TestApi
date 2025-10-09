namespace TestApi.Models.Entities
{
    public class Office
    {
        // this ? means that this is nullable 
        // the Name could be null thats whats being told with the ? 
        public Guid Id{ get; set; }
        public string? Name { get; set; }
        public string? Type_of_office { get; set; }
        public decimal Age { get; set; }
        public string? Shift { get; set; }
        public ICollection<Employee> Employees { get; set; } = [];
     
    }
}