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
    public class DoctorService : IDoctorService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Doctor> _repository;
        private readonly IGenericRepository<Hospital> _hospitalRepository;

        public DoctorService(IGenericRepository<Doctor> repository, IMapper mapper, IGenericRepository<Hospital> hospitalRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _hospitalRepository = hospitalRepository;
        }
        public async Task<DoctorDto> AddAsync(DoctorDto item)
        {
            Hospital hospital = await _hospitalRepository.GetByIdAsync(item.HospitalId);
            if (hospital == null)
            {
                 throw new Exception("Hospital not found ");
            }
            Doctor mapperItem = _mapper.Map<Doctor>(item);
            Doctor dbItem = await _repository.AddAsync(mapperItem);
            return _mapper.Map<DoctorDto>(dbItem);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public async Task<DoctorDto> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            var mapperItem = _mapper.Map<DoctorDto>(item);
            return mapperItem;
        }

        public async Task<List<DoctorDto>> GetListAsync()
        {
            var items = await _repository.GetListAsync();
            var mapperItems = _mapper.Map<List<DoctorDto>>(items);
            return mapperItems;
        }

        public DoctorDto Update(DoctorDto item)
        {
            Doctor mapperItem = _mapper.Map<Doctor>(item);
        
            Doctor dbItem = _repository.Update(mapperItem);
            var response = _mapper.Map<DoctorDto>(dbItem);
            return response;
        }
    }
}
