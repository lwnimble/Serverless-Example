using Application.Common.Exceptions;
using FluentValidation;
using MediatR;

namespace Application.Common.Behaviours
{
    public sealed class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            var errors = _validators
                .Select(validator => validator.Validate(context))
                .SelectMany(validationResult => validationResult.Errors)
                .Where(validationFailure => validationFailure != null)
                .Select(validationFailure => validationFailure.ErrorMessage)
                .Distinct()
                .ToArray();

            if (errors.Any())
            {
                throw new BadRequestException(errors);
            }

            return await next();
        }
    }
}
