namespace EmployeeChallenge.Core.Models;
public class Employee
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Phone { get; set; }
    public string ZipCode { get; set; }
    public DateTime HireDate { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
