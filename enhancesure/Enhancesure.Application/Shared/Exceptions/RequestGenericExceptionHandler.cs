using EnhanceSure.Application.Shared.Responses;
using FluentValidation;
using MediatR.Pipeline;
using Application.Shared.Extensions;

namespace EnhanceSure.Application.Shared.Exceptions {
    public class RequestGenericExceptionHandler<TRequest, TResponse, TException>: IRequestExceptionHandler<TRequest, TResponse, TException>
    where TException : Exception {
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
                }

                state.SetHandled(response);
            }
            return Task.CompletedTask;
        }
    }

}
