using mvc_machinetest.Interfaces;
using mvc_machinetest.Models;

namespace mvc_machinetest.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public Task<List<Department>> GetAllAsync()
    {
        return _departmentRepository.GetAllAsync();
    }

    public Task<Department?> GetByIdAsync(int id)
    {
        return _departmentRepository.GetByIdAsync(id);
    }

    public Task<Department> CreateAsync(Department department)
    {
        return _departmentRepository.CreateAsync(department);
    }

    public Task<Department?> UpdateAsync(Department department)
    {
        return _departmentRepository.UpdateAsync(department);
    }

    public Task<bool> DeleteAsync(int id)
    {
        return _departmentRepository.DeleteAsync(id);
    }
}