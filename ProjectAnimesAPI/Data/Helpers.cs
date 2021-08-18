using System;
using System.Collections;
using System.Linq;
using FluentValidation;
using ProjectAnimesAPI.Models;

namespace ProjectAnimesAPI.Data
{
    public class Helpers
    {
    }

    public class Validation<T>
    {
        private readonly IValidator<T> _validator;

        public Validation(IValidator<T> validator)
        {
            _validator = validator;
        }
        
        public void Validate(T obj)
        {
            var validator = _validator.Validate(obj);
            
            if (!validator.IsValid)
            {
                var exception = new Exception("Validation errors.");
                var errorsList = validator.Errors.Select(e => e.ErrorMessage);
                exception.Data["Errors"] = errorsList;
                throw exception;
            }
        }   
    }

    public static class ExceptionResponse
    {
        public static object Response(string message, object errors = null)
        {
            return new 
            {
                Message = message,
                Errors = errors,
            };
        }
    }
}