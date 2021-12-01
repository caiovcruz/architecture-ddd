using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArchitectureDDD.Domain
{
    public interface IBaseService<TEntity, TViewModel> where TEntity : BaseEntity
                                                       where TViewModel : BaseViewModel
    {
        Task<TViewModel> Add<TValidator>(TViewModel viewModel)
            where TValidator : AbstractValidator<TViewModel>;

        Task<TViewModel> Update<TValidator>(TViewModel viewModel)
            where TValidator : AbstractValidator<TViewModel>;

        Task Delete(int id);

        Task<TViewModel> GetById(int id);

        Task<IEnumerable<TViewModel>> GetAll();
    }
}
