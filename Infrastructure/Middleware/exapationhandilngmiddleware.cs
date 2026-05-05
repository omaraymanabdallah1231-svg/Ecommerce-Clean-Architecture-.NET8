using ecommerce.application.servies.interfacee.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce.infrsutractor.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DbUpdateException ex)
            {
                var loggers = context.RequestServices.GetRequiredService<IAppLogger<ExceptionMiddleware>>(); // بدل ال inject

                if (ex.InnerException is SqlException innerexeption)
                {
                    loggers.LogErrors(innerexeption, "sql exception");
                    switch(innerexeption.Number)
                    {
                      
                        case 2627:context.Response.StatusCode=StatusCodes.Status409Conflict;
                            await context.Response.WriteAsync("uniqe constraint violation");
                            break;
                        
                        case 547:
                            context.Response.StatusCode=StatusCodes.Status409Conflict;
                            await context.Response.WriteAsync("Foreign Key constraint violation");
                            break;
                        case 515:
                            context.Response.StatusCode=StatusCodes.Status400BadRequest;
                            await context.Response.WriteAsync("cannot insert null");
                            break;
                        default:
                            context.Response.StatusCode=StatusCodes.Status500InternalServerError;
                            await context.Response.WriteAsync("An error acuierd while processing the request");
                            break;



                    }
                }
              else
                {
                    loggers.LogErrors(ex, "ef core exception");

                    context.Response.StatusCode=StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsync("An error acuierd while save the changes");
                   

                }
            }

            catch(Exception ex)
            {
                var loggers = context.RequestServices.GetRequiredService<IAppLogger<ExceptionMiddleware>>();
                loggers.LogErrors(ex, "unknow exception");
                context.Response.StatusCode=StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("An error acuierd "+ex.Message);



            }
        }
    }
}
