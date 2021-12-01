using ArchitectureDDD.Domain;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureDDD.Service
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserLoginRepository _repository;
        private readonly IMapper _mapper;

        public UserLoginService(IUserLoginRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<User> Login(UserLoginViewModel viewModel)
        {
            await Activator.CreateInstance<UserLoginValidator>().ValidateAndThrowAsync(viewModel);

            if (!string.IsNullOrEmpty(viewModel.Password))
                viewModel.Password = md5Crypto(viewModel.Password);

            return await _repository.GetUser(viewModel);
        }

        private string md5Crypto(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
