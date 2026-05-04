using ecommerce.application.dto;
using FluentValidation;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.Validation.interfac
{
    public interface IvalidationServies
    {
        Task<serviesresponce> ValidationAsynac<T>(T model, IValidator<T> validator);
    }
}
