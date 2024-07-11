using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Library.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
        {
            _validators = validator;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, 
            CancellationToken cancellationToken)
        {
            ValidationContext<TRequest> context = new(request);
            List<ValidationFailure> failures = _validators
                .Select(validator => validator.Validate(context))
                .SelectMany(request => request.Errors)
                .Where(failure => failure != null)
                .ToList();

            if(failures.Count != 0)
            {
                throw new FluentValidation.ValidationException(failures);
            }

            return next();
        }
    }
}
