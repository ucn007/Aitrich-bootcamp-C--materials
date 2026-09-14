using machinetest.Data;
using machinetest.Interface;
using machinetest.Model;
using Microsoft.EntityFrameworkCore;

namespace machinetest.Repository;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly IDbContextFactory<MyDbContext> _contextFactory;

    public AppointmentRepository(
        IDbContextFactory<MyDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<List<Appoinment>> GetAllAsync()
    {
        await using var context =
            await _contextFactory.CreateDbContextAsync();

        return await context.Appoinments
            .AsNoTracking()
            .Include(x => x.Patient)
            .Include(x => x.Doctor)
            .OrderByDescending(x => x.AppointmentDate)
            .ThenByDescending(x => x.AppoinmentTime)
            .ToListAsync();
    }

    public async Task<Appoinment?> GetByIdAsync(int id)
    {
        await using var context =
            await _contextFactory.CreateDbContextAsync();

        return await context.Appoinments
            .AsNoTracking()
            .Include(x => x.Patient)
            .Include(x => x.Doctor)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Appoinment> CreateAsync(
        Appoinment appointment)
    {
        await using var context =
            await _contextFactory.CreateDbContextAsync();

        context.Appoinments.Add(appointment);

        await context.SaveChangesAsync();

        return appointment;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await using var context =
            await _contextFactory.CreateDbContextAsync();

        var appointment = await context.Appoinments
            .FirstOrDefaultAsync(x => x.Id == id);

        if (appointment == null)
        {
            return false;
        }

        context.Appoinments.Remove(appointment);

        await context.SaveChangesAsync();

        return true;
    }
}