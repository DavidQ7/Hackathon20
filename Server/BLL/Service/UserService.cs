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
        private readonly UserRepository userRepository;

        public UserService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
           var user = await userRepository.GetByEmail(email);
            //var bduser = mapper.Map<DTOUser>(user);
            return null;
        }
    }
}
