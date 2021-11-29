using ArchitectureDDD.Domain;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ArquictectureDDD.Application.Controllers
{
    public abstract class CrudBaseController<TEntity, TViewModel, TValidator> : ControllerBase
                                                                       where TEntity : BaseEntity
                                                                       where TViewModel : BaseViewModel
                                                                       where TValidator : AbstractValidator<TEntity>
    {
        private readonly IBaseService<TEntity> _baseService;

        public CrudBaseController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] TEntity viewModel)
        {
            if (viewModel == null)
                return NotFound();

            return Execute(() => _baseService.Add<TEntity, TViewModel, TValidator>(viewModel).Result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] TEntity viewModel)
        {
            if (viewModel == null)
                return NotFound();

            return Execute(() => _baseService.Update<TEntity, TViewModel, TValidator>(viewModel).Result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseService.GetAll<TViewModel>().Result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseService.GetById<TViewModel>(id).Result);
        }

        /// <summary>
        /// Método utilizando Design Pattern Strategy
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
