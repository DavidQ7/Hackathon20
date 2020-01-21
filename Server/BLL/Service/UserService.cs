using AutoMapper;
using Common.DbModels;
using Common.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class UserService
    {
        private readonly IMapper mapper;
        private readonly UserRepository userRepository;

        public UserService(UserRepository userRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            var user = await userRepository.GetByEmail(email);
            var bduser = mapper.Map<UserDTO>(user);
            return bduser;
        }
        public async Task Add(UserDTO user)
        {
            var dbuser = mapper.Map<User>(user);
            await userRepository.Add(dbuser);
        }
    }
}
