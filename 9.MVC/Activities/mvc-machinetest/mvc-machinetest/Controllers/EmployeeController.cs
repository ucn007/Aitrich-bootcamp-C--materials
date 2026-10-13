using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mvc_machinetest.DTOs.Employe;
using mvc_machinetest.Interfaces;
using mvc_machinetest.Models;

namespace mvc_machinetest.Controllers;

public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;
    private readonly IDepartmentService _departmentService;

    public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
    {
        _employeeService = employeeService;
        _departmentService = departmentService;
    }

    public async Task<IActionResult> Index()
    {
        var employees = await _employeeService.GetAllAsync();

        return View(employees);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await PopulateDepartmentsAsync();
        return View(new CreateEmployeDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeDto employeeDto)
    {
        if (ModelState.IsValid && await _departmentService.GetByIdAsync(employeeDto.DepartmentId) == null)
        {
            ModelState.AddModelError(nameof(employeeDto.DepartmentId), "Select a valid department.");
        }

        if (!ModelState.IsValid)
        {
            await PopulateDepartmentsAsync(employeeDto.DepartmentId);
            return View(employeeDto);
        }

        var employee = new Employee
        {
            Name = employeeDto.Name,
            Phone = employeeDto.Phone,
            Email = employeeDto.Email,
            DepartmentId = employeeDto.DepartmentId
        };

        await _employeeService.CreateAsync(employee);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var employee = await _employeeService.GetByIdAsync(id);

        if (employee == null)
            return NotFound();

        await PopulateDepartmentsAsync(employee.DepartmentId);
        return View(employee);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Employee employee)
    {
        if (await _departmentService.GetByIdAsync(employee.DepartmentId) == null)
        {
            ModelState.AddModelError(nameof(employee.DepartmentId), "Select a valid department.");
        }

        if (!ModelState.IsValid)
        {
            await PopulateDepartmentsAsync(employee.DepartmentId);
            return View(employee);
        }

        var updated = await _employeeService.UpdateAsync(employee);

        if (updated == null)
            return NotFound();

        return RedirectToAction(nameof(Index));
    }

    private async Task PopulateDepartmentsAsync(int? selectedDepartmentId = null)
    {
        var departments = await _departmentService.GetAllAsync();
        ViewBag.Departments = new SelectList(departments, nameof(Department.Id), nameof(Department.Name), selectedDepartmentId);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _employeeService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return RedirectToAction(nameof(Index));
    }
}