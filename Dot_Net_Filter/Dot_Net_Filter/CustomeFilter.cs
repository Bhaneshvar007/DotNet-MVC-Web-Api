using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Dot_Net_Filter
{
    // Custom filter implementing Authorization, Resource, Exception, and Result filters
    public class CustomFilter : Attribute,
        IAuthorizationFilter,
        IResourceFilter,
        IExceptionFilter,
        IResultFilter
    {
        // IAuthorizationFilter implementation
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Authorization logic
            Console.WriteLine("Authorization Filter: Checking if the user is authorized.");

            if (context.HttpContext.User.Identity.Name == "User")
            {
                context.Result = new UnauthorizedResult();  
            }
        }

        // IResourceFilter implementation
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            // Before the action executes
            Console.WriteLine("Resource Filter: Executing resource logic before the action.");
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            // After the action executes
            Console.WriteLine("Resource Filter: Executed resource logic after the action.");
        }

        // IExceptionFilter implementation
        public void OnException(ExceptionContext context)
        {
            // Handle exceptions
            Console.WriteLine($"Exception Filter: An exception occurred. Message: {context.Exception.Message}");
            context.ExceptionHandled = true; // Mark exception as handled
        }

        // IResultFilter implementation
        public void OnResultExecuting(ResultExecutingContext context)
        {
            // Before result is returned to the client
            Console.WriteLine("Result Filter: Executing result logic before sending response.");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            // After result is returned to the client
            Console.WriteLine("Result Filter: Executed result logic after sending response.");
        }
    }
}
