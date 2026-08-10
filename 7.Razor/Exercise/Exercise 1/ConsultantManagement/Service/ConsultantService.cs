using ConsultantManagement.Dto;
using ConsultantManagement.Interface;
using ConsultantManagement.Model;
using ConsultantManagement.Repository;
using ConsultantManagement.Enums;

namespace ConsultantManagement.Service
{
    public class ConsultantService : IConsultantService
    {
        private readonly ConsultantRepository consultantRepository;
        public ConsultantService(ConsultantRepository _consultantRepository)
        {
            consultantRepository = _consultantRepository;
        }
    
       
        public async Task AddConsultantAsync(ConsultantDto consultantDto,int regsterId)
        {
            await consultantRepository.AddConsultantAsync(consultantDto,regsterId);
        }

        public async Task DeleteConsultantAsync(int id,int regsterId)
        {
           await consultantRepository.DeleteConsultantAsync(id, regsterId);
        }

        public async Task<List<Consultants>> GetAllConsultantAsync(int regsterId)
        {
            return await consultantRepository.GetAllConsultantAsync(regsterId);
        }

        public async Task<Consultants> GetConsultantByIdAsync(int id)
        {
           return await consultantRepository.GetConsultantByIdAsync(id);
        }

        public async Task<int> GetTotalConsultantsByUserAsync(int registerId)
        {
            return await consultantRepository.GetTotalConsultantsByUserAsync(registerId);
        }

        public async Task UpdateConsultantAsync(int id, Consultants consultantDto)
        {
           await consultantRepository.UpdateConsultantAsync(id, consultantDto);
        }
    }
}
