using HMS.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BLL.Services.Interface
{
    public interface IDoctorService
    {
        public Task<DoctorDto> AddAsync(DoctorDto item);
        public Task<DoctorDto> GetByIdAsync(int id);
        public Task<List<DoctorDto>> GetListAsync();
        public void Delete(int id);
        public DoctorDto Update(DoctorDto item);
    }
}
