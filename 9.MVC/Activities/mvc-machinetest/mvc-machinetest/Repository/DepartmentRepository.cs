using Microsoft.EntityFrameworkCore;
using mvc_machinetest.Data;
using mvc_machinetest.Interfaces;
using mvc_machinetest.Models;

namespace mvc_machinetest.Repository;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly MyDbContext _context;

    public DepartmentRepository(MyDbContext context)
    {
        _context = context;
    }

    public Task<List<Department>> GetAllAsync()
    {
        return _context.Departments
            .Include(department => department.Employees)
            .OrderBy(department => department.Name)
            .ToListAsync();
    }

    public Task<Department?> GetByIdAsync(int id)
    {
        return _context.Departments
            .Include(department => department.Employees)
            .FirstOrDefaultAsync(department => department.Id == id);
    }

    public async Task<Department> CreateAsync(Department department)
    {
        _context.Departments.Add(department);
        await _context.SaveChangesAsync();
        return department;
    }

    public async Task<Department?> UpdateAsync(Department department)
    {
        var existingDepartment = await _context.Departments
            .FirstOrDefaultAsync(item => item.Id == department.Id);

        if (existingDepartment == null)
        {
            return null;
        }

        existingDepartment.Name = department.Name;
        await _context.SaveChangesAsync();
        return existingDepartment;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingDepartment = await _context.Departments
            .FirstOrDefaultAsync(item => item.Id == id);

        if (existingDepartment == null || await _context.Employees.AnyAsync(employee => employee.DepartmentId == id))
        {
            return false;
        }

        _context.Departments.Remove(existingDepartment);
        await _context.SaveChangesAsync();
        return true;
    }
}