using HMS.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BLL.Services.Interface
{
    public interface IHospitalService
    {
        public Task< HospitalDto> AddAsync(HospitalDto item);
        public Task<HospitalDto> GetByIdAsync(int id);
        public Task<List<HospitalDto>> GetListAsync();
        public void Delete(int id);
        public HospitalDto Update(HospitalDto item);
    }
}
