using AutoMapper;
using ConsultantManagement.Dto;
using ConsultantManagement.Interface;
using ConsultantManagement.Migrations;
using ConsultantManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace ConsultantManagement.Repository
{
    public class ConsultantRepository:IConsultantRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ConsultantRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddConsultantAsync(ConsultantDto consultantDto, int regsterId)
        {
            var consultants = _mapper.Map<Consultants>(consultantDto);
            consultants.RegisterId = regsterId;
            _context.Consultants.Add(consultants);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteConsultantAsync(int id,int registerId)
        {
            var consultant = await _context.Consultants
      .FirstOrDefaultAsync(x => x.Id == id && x.RegisterId == registerId);
            if (consultant != null)
            {
                _context.Consultants.Remove(consultant);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Consultants>> GetAllConsultantAsync(int registerId)
        {
            var consultants = await _context.Consultants.Where(x => x.RegisterId == registerId)
          .ToListAsync();

            return _mapper.Map<List<Consultants>>(consultants);
            
        }

        public async Task<Consultants> GetConsultantByIdAsync(int id)
        {

            var consultant = await _context.Consultants.FindAsync(id);
            return _mapper.Map<Consultants>(consultant);
        }

        public async Task UpdateConsultantAsync(int id, Consultants consultantDto)
        {
            var consultant = await _context.Consultants.FindAsync(id);

            if (consultant != null)
            {
                consultant.Name = consultantDto.Name;
                consultant.Phone = consultantDto.Phone;
                consultant.Username = consultantDto.Username;
                consultant.Password = consultantDto.Password;
                consultant.AssignedTours = consultantDto.AssignedTours;
                consultant.Bookings = consultantDto.Bookings;
                consultant.Status = consultantDto.Status;
                consultant.JoinedDate = consultantDto.JoinedDate;

                await _context.SaveChangesAsync();
            }

        }
        public async Task<int> GetTotalConsultantsByUserAsync(int registerId)
        {
            return await _context.Consultants.Where(c => c.RegisterId == registerId)
          .CountAsync();
        }
    }
}
