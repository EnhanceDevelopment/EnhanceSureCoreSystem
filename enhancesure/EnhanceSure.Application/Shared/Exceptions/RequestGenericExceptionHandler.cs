using EnhanceSure.Application.Shared.Responses;
using FluentValidation;
using MediatR.Pipeline;
using Application.Shared.Extensions;
using EnhanceSure.Application.Contracts.Persistances;

namespace EnhanceSure.Application.Shared.Exceptions {
    public class RequestGenericExceptionHandler<TRequest, TResponse, TException>: IRequestExceptionHandler<TRequest, TResponse, TException>
    where TException : Exception {
        private readonly ILogger _logger;

        public RequestGenericExceptionHandler(ILogger logger)
        {
            _logger=logger;
        }

        public Task Handle(TRequest request,
            TException exception,
            RequestExceptionHandlerState<TResponse> state,
            CancellationToken cancellationToken)
        {
            var response = (TResponse)Activator.CreateInstance(typeof(TResponse));

            if(response is IAppResponse appResponse)
            {
                if(exception is ValidationException fluentException)
                {
                    appResponse.StatusCode=System.Net.HttpStatusCode.BadRequest;
                    appResponse.Messages=fluentException.Errors.Select(e => e.ToString()).ToArray();
                } else
                {
                    appResponse.StatusCode=System.Net.HttpStatusCode.InternalServerError;
                    appResponse.Messages=new string[] { exception.Flatten() };
                    _logger.LogErrorAsync(exception, cancellationToken, Domain.Enum.ErrorCategory.UNH);
                }

                state.SetHandled(response);
            }
            return Task.CompletedTask;
        }
    }

}
