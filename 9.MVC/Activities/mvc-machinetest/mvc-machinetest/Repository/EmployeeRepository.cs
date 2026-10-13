using Microsoft.EntityFrameworkCore;
using mvc_machinetest.Data;
using mvc_machinetest.Interfaces;
using mvc_machinetest.Models;

namespace mvc_machinetest.Repository;

public class EmployeeRepository:IEmployeeRepository
{
    
    private readonly MyDbContext context;
    
    public EmployeeRepository(MyDbContext context)
    {
        this.context = context;
    }

   public async Task<List<Employee>> GetAllAsync()
    {
       return await context.Employees
           .Include(employee => employee.Department)
           .ToListAsync();
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await context.Employees.FindAsync(id);
    }

    public async Task<Employee> CreateAsync(Employee employee)
    {
        context.Employees.Add(employee);
        await context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee?> UpdateAsync(Employee employee)
    {
        var existingEmployee = await context.Employees
            .FirstOrDefaultAsync(e => e.Id == employee.Id);

        if (existingEmployee == null)
            return null;

        existingEmployee.Name = employee.Name;
        existingEmployee.Email = employee.Email;
        existingEmployee.Phone = employee.Phone;
        existingEmployee.DepartmentId = employee.DepartmentId;

        await context.SaveChangesAsync();

        return existingEmployee;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingEmployee = await context.Employees
            .FirstOrDefaultAsync(e => e.Id == id);

        if (existingEmployee == null)
        {
            return false;
        }

        context.Employees.Remove(existingEmployee);

        await context.SaveChangesAsync();

        return true;
    }
}