using AutoMapper;
using HMS.DAL.DBModel;
using HMS.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BLL.Mapping
{
    public class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<Hospital, HospitalDto>().ReverseMap();
            CreateMap<Doctor, DoctorDto>().ReverseMap();

        }

    }
}
