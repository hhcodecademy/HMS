using HMS.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BLL.Services.Interface
{
    public interface IAppointmentService
    {
        public Task<AppointmentDto> AddAsync(AppointmentDto item);
        public Task<AppointmentDto> GetByIdAsync(int id);
        public Task<List<AppointmentDto>> GetListAsync();
        public void Delete(int id);
        public AppointmentDto Update(AppointmentDto item);
    }
}
