using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArchitectureDDD.Domain
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        Task<TOutputModel> Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class;

        Task<TOutputModel> Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class;

        Task Delete(int id);

        Task<TOutputModel> GetById<TOutputModel>(int id) where TOutputModel : class;

        Task<IEnumerable<TOutputModel>> GetAll<TOutputModel>() where TOutputModel : class;
    }
}
