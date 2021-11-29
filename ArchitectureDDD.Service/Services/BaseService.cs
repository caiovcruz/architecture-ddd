using ArchitectureDDD.Domain;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureDDD.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<TOutputModel> Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class
        {
            TEntity entity = _mapper.Map<TEntity>(inputModel);

            Validate(entity, Activator.CreateInstance<TValidator>());

            await _baseRepository.Add(entity);

            return _mapper.Map<TOutputModel>(entity);
        }

        public async Task<TOutputModel> Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class
        {
            TEntity entity = _mapper.Map<TEntity>(inputModel);

            Validate(entity, Activator.CreateInstance<TValidator>());

            await _baseRepository.Update(entity);

            return _mapper.Map<TOutputModel>(entity);
        }

        public Task Delete(int id) => _baseRepository.Delete(id);

        public async Task<IEnumerable<TOutputModel>> GetAll<TOutputModel>() where TOutputModel : class
        {
            var entities = await _baseRepository.GetAll();

            return _mapper.Map<IEnumerable<TOutputModel>>(entities);
        }

        public async Task<TOutputModel> GetById<TOutputModel>(int id) where TOutputModel : class
        {
            var entity = await _baseRepository.GetByIdAsync(id);

            return _mapper.Map<TOutputModel>(entity);
        }

        private void Validate(TEntity entity, AbstractValidator<TEntity> validator)
        {
            if (entity == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(entity);
        }
    }
}
