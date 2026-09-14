using machinetest.Data;
using machinetest.Interface;
using machinetest.Model;
using Microsoft.EntityFrameworkCore;

namespace machinetest.Repository;

public class DoctorRepository : IDoctorRepository
{
    private readonly IDbContextFactory<MyDbContext> _contextFactory;

    public DoctorRepository(IDbContextFactory<MyDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<List<Doctor>> GetAllAsync()
    {
        await using var context =
            await _contextFactory.CreateDbContextAsync();

        return await context.Doctors
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Doctor?> GetByIdAsync(int id)
    {
        await using var context =
            await _contextFactory.CreateDbContextAsync();

        return await context.Doctors
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Doctor> CreateAsync(Doctor doctor)
    {
        await using var context =
            await _contextFactory.CreateDbContextAsync();

        context.Doctors.Add(doctor);

        await context.SaveChangesAsync();

        return doctor;
    }

    public async Task<Doctor?> UpdateAsync(Doctor doctor)
    {
        await using var context =
            await _contextFactory.CreateDbContextAsync();

        var existingDoctor = await context.Doctors
            .FirstOrDefaultAsync(x => x.Id == doctor.Id);

        if (existingDoctor == null)
        {
            return null;
        }

        existingDoctor.Name = doctor.Name;
        existingDoctor.Specialization = doctor.Specialization;
        existingDoctor.Department = doctor.Department;
        existingDoctor.ConsultationFee = doctor.ConsultationFee;
        existingDoctor.Available = doctor.Available;

        await context.SaveChangesAsync();

        return existingDoctor;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await using var context =
            await _contextFactory.CreateDbContextAsync();

        var doctor = await context.Doctors
            .FirstOrDefaultAsync(x => x.Id == id);

        if (doctor == null)
        {
            return false;
        }

        context.Doctors.Remove(doctor);

        await context.SaveChangesAsync();

        return true;
    }
}