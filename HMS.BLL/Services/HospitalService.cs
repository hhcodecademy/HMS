using AutoMapper;
using HMS.BLL.Services.Interface;
using HMS.DAL.Data;
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
    public class HospitalService : IHospitalService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Hospital> _repository;

        public HospitalService(IGenericRepository<Hospital> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<HospitalDto> AddAsync(HospitalDto item)
        {

            Hospital mapperItem = _mapper.Map<Hospital>(item);
            Hospital dbItem = await _repository.AddAsync(mapperItem);
            return _mapper.Map<HospitalDto>(dbItem);
        }
        public HospitalDto Update(HospitalDto item)
        {
            Hospital mapperItem = _mapper.Map<Hospital>(item);
            Hospital dbItem =  _repository.Update(mapperItem);
            var response= _mapper.Map<HospitalDto>(dbItem);
            return response;
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public async Task<HospitalDto> GetByIdAsync(int id)
        {

            var item = await _repository.GetByIdAsync(id);
            var mapperItem = _mapper.Map<HospitalDto>(item);
            return mapperItem;
        }

        public async Task<List<HospitalDto>> GetListAsync()
        {
            var items = await _repository.GetListAsync();
            var mapperItems = _mapper.Map<List<HospitalDto>>(items);
            return mapperItems;
        }

      
    }
}
