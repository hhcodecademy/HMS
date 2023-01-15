using AutoMapper;
using HMS.BLL.Services.Interface;
using HMS.DAL.DBModel;
using HMS.DAL.Dtos;
using HMS.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BLL.Services
{
    public class AppointmentService: IAppointmentService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Appointment> _repository;

        public AppointmentService(IGenericRepository<Appointment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<AppointmentDto> AddAsync(AppointmentDto item)
        {

            Appointment mapperItem = _mapper.Map<Appointment>(item);
            Appointment dbItem = await _repository.AddAsync(mapperItem);
            return _mapper.Map<AppointmentDto>(dbItem);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public async Task<AppointmentDto> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            var mapperItem = _mapper.Map<AppointmentDto>(item);
            return mapperItem;
        }

        public async Task<List<AppointmentDto>> GetListAsync()
        {
            var items = await _repository.GetListAsync();
            var mapperItems = _mapper.Map<List<AppointmentDto>>(items);
            return mapperItems;
        }

        public AppointmentDto Update(AppointmentDto item)
        {
            Appointment mapperItem = _mapper.Map<Appointment>(item);
            Appointment dbItem = _repository.Update(mapperItem);
            var response = _mapper.Map<AppointmentDto>(dbItem);
            return response;
        }
    }
}
