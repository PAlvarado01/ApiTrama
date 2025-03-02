﻿using FluentValidation;
using Grupo5.Input;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Grupo5.Business.Services
{
    public abstract class InputService
    {
        protected string Validations<TV, TE>(TV validacao, TE entidade)
            where TV : AbstractValidator<TE>
            where TE : Request
        {
            var builder = new StringBuilder();
            var validator = validacao.Validate(entidade).Errors.ToList();

            foreach (var error in validator)
            {
                error.PropertyName = error.PropertyName.Split('.').ToList().LastOrDefault();
                builder.AppendLine($"{error.ErrorMessage} <br/>");
            }

            return builder.ToString();
        }
    }
}
