using System;
using System.Collections;
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
                exception.Data["Errors"] = validator.Errors;
                throw exception;
            }
        }   
    }

    public class ExceptionResponse
    {
        private readonly string Message;
        private readonly object Errors;

        public ExceptionResponse(string message, object errors = null)
        {
            Message = message;
            Errors = errors;
        }
    }
}