using Data.Entities;
using Data.Repositories.interfaces;
using Service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(User user)
        {
            // Validaciones o lógica adicional
            _userRepository.Add(user);
        }

        public User GetUserById(int id)
        {
            // Validaciones o lógica adicional
            return _userRepository.GetById(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            // Validaciones o lógica adicional
            return _userRepository.GetAll();
        }

        public void UpdateUser(User user)
        {
            // Validaciones o lógica adicional
            _userRepository.Update(user);
        }

        public void DeleteUser(int id)
        {
            // Validaciones o lógica adicional
            _userRepository.Delete(id);
        }
    }
}
