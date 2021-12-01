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
    public class BaseService<TEntity, TViewModel> : IBaseService<TEntity, TViewModel> where TEntity : BaseEntity
                                                                                      where TViewModel : BaseViewModel
    {
        private readonly IBaseRepository<TEntity> _baseRepository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }


        public async Task<TViewModel> Add<TValidator>(TViewModel viewModel) where TValidator : AbstractValidator<TViewModel>

        {
            await Activator.CreateInstance<TValidator>().ValidateAndThrowAsync(viewModel);

            TEntity entity = _mapper.Map<TEntity>(viewModel);

            await _baseRepository.Add(entity);

            return _mapper.Map<TViewModel>(entity);
        }


        public async Task<TViewModel> Update<TValidator>(TViewModel viewModel) where TValidator : AbstractValidator<TViewModel>

        {
            await Activator.CreateInstance<TValidator>().ValidateAndThrowAsync(viewModel);

            TEntity entity = _mapper.Map<TEntity>(viewModel);

            await _baseRepository.Update(entity);

            return _mapper.Map<TViewModel>(entity);
        }


        public async Task Delete(int id) => await _baseRepository.Delete(id);


        public async Task<IEnumerable<TViewModel>> GetAll() => _mapper.Map<IEnumerable<TViewModel>>(await _baseRepository.GetAll());


        public async Task<TViewModel> GetById(int id) => _mapper.Map<TViewModel>(await _baseRepository.GetByIdAsync(id));
    }
}
