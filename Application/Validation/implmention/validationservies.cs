using ecommerce.application.dto;
using ecommerce.application.Validation.interfac;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.Validation.implmention
{
  public  class validationservies : IvalidationServies
    {
        public async Task<serviesresponce> ValidationAsynac<T>(T model, IValidator<T> validator)
        {
            var result = await validator.ValidateAsync(model);
            if(!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                string errorjoin = string.Join(";", errors);
                return new serviesresponce(false, errorjoin);
               
            }
            return new serviesresponce(true,"clean");

        }
    }
}
