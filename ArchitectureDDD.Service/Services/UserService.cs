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
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<UserViewModel> Add<TValidator>(UserViewModel viewModel) where TValidator : AbstractValidator<UserViewModel>
        {
            viewModel.Password = md5Crypto(viewModel.Password);

            var existingUser = _repository.GetAll().Result.Where(
                x => x.UserName.Equals(viewModel.UserName, StringComparison.OrdinalIgnoreCase) ||
                     x.Email.Equals(viewModel.Email, StringComparison.OrdinalIgnoreCase));

            if (!existingUser.Any())
            {
                await Activator.CreateInstance<TValidator>().ValidateAndThrowAsync(viewModel);

                var entity = _mapper.Map<User>(viewModel);

                await _repository.Add(entity);

                return _mapper.Map<UserViewModel>(entity);
            }

            return null;
        }


        public async Task<UserViewModel> Update<TValidator>(UserViewModel viewModel) where TValidator : AbstractValidator<UserViewModel>
        {
            if (!string.IsNullOrEmpty(viewModel.Password))
                viewModel.Password = md5Crypto(viewModel.Password);

            await Activator.CreateInstance<TValidator>().ValidateAndThrowAsync(viewModel);

            var entity = _mapper.Map<User>(viewModel);

            await _repository.Update(entity);

            return _mapper.Map<UserViewModel>(entity);
        }


        public async Task Delete(int id) => await _repository.Delete(id);


        public async Task<IEnumerable<UserViewModel>> GetAll() => _mapper.Map<IEnumerable<UserViewModel>>(await _repository.GetAll());


        public async Task<UserViewModel> GetById(int id) => _mapper.Map<UserViewModel>(await _repository.GetByIdAsync(id));


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
