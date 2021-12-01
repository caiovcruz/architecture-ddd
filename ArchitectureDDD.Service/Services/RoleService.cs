using ArchitectureDDD.Domain;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitectureDDD.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<RoleViewModel> Add<TValidator>(RoleViewModel viewModel) where TValidator : AbstractValidator<RoleViewModel>
        {
            var existingRole = _repository.GetAll().Result.Where(x => x.Name.Equals(viewModel.Name, StringComparison.OrdinalIgnoreCase));

            if (!existingRole.Any())
            {
                await Activator.CreateInstance<TValidator>().ValidateAndThrowAsync(viewModel);

                var entity = _mapper.Map<Role>(viewModel);

                await _repository.Add(entity);

                return _mapper.Map<RoleViewModel>(entity);
            }

            return null;
        }


        public async Task<RoleViewModel> Update<TValidator>(RoleViewModel viewModel) where TValidator : AbstractValidator<RoleViewModel>
        {
            await Activator.CreateInstance<TValidator>().ValidateAndThrowAsync(viewModel);

            var entity = _mapper.Map<Role>(viewModel);

            await _repository.Update(entity);

            return _mapper.Map<RoleViewModel>(entity);
        }


        public async Task Delete(int id) => await _repository.Delete(id);


        public async Task<IEnumerable<RoleViewModel>> GetAll() => _mapper.Map<IEnumerable<RoleViewModel>>(await _repository.GetAll());


        public async Task<RoleViewModel> GetById(int id) => _mapper.Map<RoleViewModel>(await _repository.GetByIdAsync(id));
    }
}
