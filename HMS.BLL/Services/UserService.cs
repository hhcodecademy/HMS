﻿using AutoMapper;
using HMS.BLL.Services.Interface;
using HMS.DAL.DBModel;
using HMS.DAL.Dtos;
using HMS.DAL.Repositories;
using HMS.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BLL.Services
{
    public class UserService : IUserService
    {

        private readonly IMapper _mapper;
        private readonly IGenericRepository<LocalUser> _repository;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IGenericRepository<LocalUser> repository, IUserRepository userrepository, IMapper mapper, IConfiguration configuration)
        {

            _repository = repository;
            _userRepository = userrepository;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<LocalUserDto> AddAsync(LocalUserDto item)
        {

            LocalUser mapperItem = _mapper.Map<LocalUser>(item);
            LocalUser dbItem = await _repository.AddAsync(mapperItem);
            return _mapper.Map<LocalUserDto>(dbItem);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public async Task<LocalUserDto> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            var mapperItem = _mapper.Map<LocalUserDto>(item);
            return mapperItem;
        }

        public async Task<List<LocalUserDto>> GetListAsync()
        {
            var items = await _repository.GetListAsync();
            var mapperItems = _mapper.Map<List<LocalUserDto>>(items);
            return mapperItems;
        }

        public LocalUserDto Update(LocalUserDto item)
        {
            LocalUser mapperItem = _mapper.Map<LocalUser>(item);
            LocalUser dbItem = _repository.Update(mapperItem);
            var response = _mapper.Map<LocalUserDto>(dbItem);
            return response;
        }

        public bool IsUnique(string userName)
        {
            return _userRepository.IsUnique(userName);
        }

        public LocalUserResponseDto Login(SignInRequestDto loginRequestDto)
        {
            LocalUserResponseDto localUserResponseDto = null;
            LocalUser localUser = _userRepository.Login(loginRequestDto);
            if (localUser == null)
            {
                localUserResponseDto = new LocalUserResponseDto
                {
                    UserDto = null,
                    Token = String.Empty
                };
                return localUserResponseDto;
            }
            var key = Encoding.ASCII.GetBytes
 (_configuration.GetValue<string>("SecretInfo:SecretKey"));
            var mapperItem = _mapper.Map<LocalUserDto>(localUser);
            // eger user tapsaq token generate edeceyik
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                 new Claim(ClaimTypes.Name,localUser.Id.ToString()),
                 new Claim(ClaimTypes.Role,localUser.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            LocalUserResponseDto loginResponseDto = new LocalUserResponseDto
            {
                Token = tokenHandler.WriteToken(token),
                UserDto = new LocalUserDto
                {
                    Id = localUser.Id,
                    Email = localUser.Email,

                    Password = localUser.Password
                }
            };
            return loginResponseDto;
        }

       
    }
}
