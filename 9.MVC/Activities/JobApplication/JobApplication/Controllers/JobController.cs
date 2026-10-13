using System.Security.Claims; 
using JobApplication.DTOs.Job;
using JobApplication.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobApplication.Controllers;

[Authorize]
public class JobController : Controller
{
    private readonly IJobServices _jobService;

    public JobController(IJobServices jobService)
    {
        _jobService = jobService;
    }

    // =========================================================
    // JOB LIST
    // =========================================================

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var jobs = await _jobService.GetAllAsync();
        return View(jobs);
    }


    // =========================================================
    // JOB DETAILS
    // =========================================================

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Details(Guid id)
    {
        var job = await _jobService.GetByIdAsync(id);

        if (job == null)
            return NotFound();

        return View(job);
    }


    // =========================================================
    // MY JOBS
    // =========================================================

    [HttpGet]
    public async Task<IActionResult> MyJobs()
    {
        var companyId = GetCompanyId();

        if (companyId == null)
        {
            return Content("Company ID was not found in the logged-in user's claims.");
        }

        var jobs = await _jobService.GetByCompanyIdAsync(companyId.Value);

        return View(jobs);
    }


    // =========================================================
    // CREATE - GET
    // =========================================================

    [HttpGet]
    public IActionResult Create()
    {
        return View(new CreateJobDto());
    }


    // =========================================================
    // CREATE - POST
    // =========================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateJobDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        var companyId = GetCompanyId();

        if (companyId == null)
        {
            return Content("Company ID was not found in the logged-in user's claims.");
        }

        await _jobService.CreateAsync(dto, companyId.Value);

        return RedirectToAction("Index", "Company");
    }


    // =========================================================
    // EDIT - GET
    // =========================================================

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var companyId = GetCompanyId();

        if (companyId == null)
        {
            return Content("Company ID was not found in the logged-in user's claims.");
        }

        var job = await _jobService.GetByIdAsync(id);

        if (job == null)
        {
            return NotFound();
        }

        if (job.CompId != companyId.Value)
        {
            return Forbid();
        }

        var dto = new UpdateJobDto
        {
            JobTitle = job.JobTitle,
            Description = job.Description,
            Experience = job.Experience,
            JobType = job.JobType, 
        };

        return View(dto);
    }


    // =========================================================
    // EDIT - POST
    // =========================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        Guid id,
        UpdateJobDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        var companyId = GetCompanyId();

        if (companyId == null)
        {
            return Content("Company ID was not found in the logged-in user's claims.");
        }

        var job = await _jobService.UpdateAsync(
            id,
            dto,
            companyId.Value);

        if (job == null)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(MyJobs));
    }


    // =========================================================
    // DELETE - GET
    // =========================================================

    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        var companyId = GetCompanyId();

        if (companyId == null)
        {
            return Content("Company ID was not found in the logged-in user's claims.");
        }

        var job = await _jobService.GetByIdAsync(id);

        if (job == null)
        {
            return NotFound();
        }

        if (job.CompId != companyId.Value)
        {
            return Forbid();
        }

        return View(job);
    }


    // =========================================================
    // DELETE - POST
    // =========================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var companyId = GetCompanyId();

        if (companyId == null)
        {
            return Content("Company ID was not found in the logged-in user's claims.");
        }

        var deleted = await _jobService.DeleteAsync(
            id,
            companyId.Value);

        if (!deleted)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(MyJobs));
    }


    // =========================================================
    // GET COMPANY ID
    // =========================================================

    private Guid? GetCompanyId()
    {
        var companyId = User.FindFirstValue("CompId");

        if (string.IsNullOrEmpty(companyId))
        {
            return null;
        }

        if (!Guid.TryParse(companyId, out var result))
        {
            return null;
        }

        return result;
    }
}
 
