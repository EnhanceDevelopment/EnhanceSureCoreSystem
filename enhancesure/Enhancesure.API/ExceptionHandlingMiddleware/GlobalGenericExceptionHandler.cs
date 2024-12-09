using Application.Shared.Extensions;
using EnhanceSure.Application.Shared.Responses;
using FluentValidation;
using MediatR.Pipeline;

namespace EnhanceSure.API.ExceptionHandlingMiddleware {
    public class GlobalGenericExceptionHandler<TRequest, TResponse, TException>
        : IRequestExceptionHandler<TRequest, TResponse, TException>
        where TException : Exception 
        {
        private readonly ILogger<GlobalGenericExceptionHandler<TRequest, TResponse, TException>> _logger;
        public GlobalGenericExceptionHandler(ILogger<GlobalGenericExceptionHandler<TRequest, TResponse, TException>> logger)
        {
            _logger=logger;
        }
        public Task Handle(TRequest request,TException exception,RequestExceptionHandlerState<TResponse> state,CancellationToken cancellationToken)
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
        //public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state,
        //    CancellationToken cancellationToken)
        //{
        //    var ex = exception.Demystify();

        //    _logger.LogError(ex, "Something went wrong while handling request of type {@requestType}", typeof(TRequest));

        //    var response = new TResponse
        //    {
        //        HasError=true,
        //        Message="A server error ocurred",
        //    };

        //    state.SetHandled(response);

        //    return Task.CompletedTask;
        //}
    }
}
