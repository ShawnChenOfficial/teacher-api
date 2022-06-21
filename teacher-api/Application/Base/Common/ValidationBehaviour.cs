﻿using System;
using FluentValidation;
using MediatR;

namespace teacher_api.Application.Base.Common
{
	public class ValidationBehavior<TRequest, TResponse>: IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var errors = _validators.Select(x => x.Validate(context)).SelectMany(x => x.Errors).Where(x => x != null).ToList();

                if (errors.Any())
                {
                    throw new ValidationException(errors);
                }
            }
            
            return await next();
        }
    }
}

