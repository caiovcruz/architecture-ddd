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
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _repository;
        private readonly IMapper _mapper;

        public UserRoleService(IUserRoleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<UserRoleViewModel> Add<TValidator>(UserRoleViewModel viewModel) where TValidator : AbstractValidator<UserRoleViewModel>
        {
            var existingUserRole = _repository.GetAll().Result.Where(x => x.UserId.Equals(viewModel.UserId) && x.RoleId.Equals(viewModel.RoleId));

            if (!existingUserRole.Any())
            {
                await Activator.CreateInstance<TValidator>().ValidateAndThrowAsync(viewModel);

                var entity = _mapper.Map<UserRole>(viewModel);

                await _repository.Add(entity);

                return _mapper.Map<UserRoleViewModel>(entity);
            }

            return null;
        }


        public async Task<UserRoleViewModel> Update<TValidator>(UserRoleViewModel viewModel) where TValidator : AbstractValidator<UserRoleViewModel>
        {
            await Activator.CreateInstance<TValidator>().ValidateAndThrowAsync(viewModel);

            var entity = _mapper.Map<UserRole>(viewModel);

            await _repository.Update(entity);

            return _mapper.Map<UserRoleViewModel>(entity);
        }


        public async Task Delete(int id) => await _repository.Delete(id);


        public async Task<IEnumerable<UserRoleViewModel>> GetAll() => _mapper.Map<IEnumerable<UserRoleViewModel>>(await _repository.GetAll());


        public async Task<UserRoleViewModel> GetById(int id) => _mapper.Map<UserRoleViewModel>(await _repository.GetByIdAsync(id));
    }
}
