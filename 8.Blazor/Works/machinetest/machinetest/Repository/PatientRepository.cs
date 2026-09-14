using machinetest.Data;
using machinetest.Interface;
using machinetest.Model;
using Microsoft.EntityFrameworkCore;

namespace machinetest.Repository;

public class PatientRepository : IPatientRepository
{
    private readonly IDbContextFactory<MyDbContext> _contextFactory;

    public PatientRepository(IDbContextFactory<MyDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<List<Patient>> GetAllAsync()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        return await context.Patients
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Patient?> GetByIdAsync(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        return await context.Patients
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Patient> CreateAsync(Patient patient)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        context.Patients.Add(patient);

        await context.SaveChangesAsync();

        return patient;
    }

    public async Task<Patient?> UpdateAsync(Patient patient)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        var existingPatient = await context.Patients
            .FirstOrDefaultAsync(x => x.Id == patient.Id);

        if (existingPatient == null)
        {
            return null;
        }

        existingPatient.PatientName = patient.PatientName;
        existingPatient.Phone = patient.Phone;
        existingPatient.Email = patient.Email;
        existingPatient.Gender = patient.Gender;
        existingPatient.Dob = patient.Dob;

        await context.SaveChangesAsync();

        return existingPatient;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        var patient = await context.Patients
            .FirstOrDefaultAsync(x => x.Id == id);

        if (patient == null)
        {
            return false;
        }

        context.Patients.Remove(patient);

        await context.SaveChangesAsync();

        return true;
    }
}