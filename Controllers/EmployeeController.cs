using Microsoft.AspNetCore.Mvc;

namespace employee_register_system;

[ApiController]
[Route("[controller]")]
public class EmployeeController: ControllerBase
{
    private readonly EmployeeContext _context;
    public EmployeeController(EmployeeContext context)
    {
        _context = context;
    }
    [HttpGet("{id}")]
    public IActionResult GetByID(int id)
    {
        var employee = _context.Employees.Find(id);
        if(employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }
    [HttpPost]
    public IActionResult Create(Employee employee)
    {
        _context.Add(employee);
        _context.SaveChanges();
        return Ok(employee);
    }
    [HttpPut("{id}")]
    public IActionResult Update(int id, Employee employee)
    {
        var employeeData = _context.Employees.Find(id);
        if(employeeData == null)
        {
            return NotFound();
        }

        employeeData.Name = employee.Name;
        employeeData.Address = employee.Address;
        employeeData.BranchLine = employee.BranchLine;
        employeeData.Email = employee.Email;
        employeeData.Salary = employee.Salary;

        _context.SaveChanges();
        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var employee = _context.Employees.Find(id);
        if(employee == null)
        {
            return NotFound();
        }
        _context.Employees.Remove(employee);
        _context.SaveChanges();
        return NoContent();
    }
}