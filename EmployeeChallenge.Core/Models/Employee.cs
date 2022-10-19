using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeChallenge.Core.Models;
public class Employee
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Phone { get; set; }
    public string ZipCode { get; set; }
    public DateTimeOffset HireDate { get; set; }   
}
