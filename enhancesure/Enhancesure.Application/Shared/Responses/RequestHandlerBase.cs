using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace BindraSawMill.Application.Shared.Responses {
    public  class RequestHandlerBase {
        private readonly IServiceProvider _serviceProvider;

        protected RequestHandlerBase()
        {

        }

        protected RequestHandlerBase(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected IDbConnection CreateConnection()
        {
            if(_serviceProvider == null)
            {
                throw new InvalidOperationException("RequestHandlerBase needs to be initialed with IServiceProvider in order to request this feature");
            }
            var factory = _serviceProvider.GetService<IDbConnectionFactory>();
            return factory?.CreateConnection();
        }

        public AppResponse<T> Ok<T>(T data, string[] messages = null)
        {
            return new AppResponse<T>
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Data = data,
                Messages = messages
            };
        }

        public PaginatedAppResponse<T> Ok<T>(IEnumerable<T> data, int pageIndex, int pageSize, int? rowsCount = null, string[] messages = null)
        {
            var list = data.ToList();
            return new PaginatedAppResponse<T>
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Data = new PaginatedAppResponse<T>.PaginatedWrapper
                {
                    Items = list.Take(pageSize).ToList(),
                    HasNextPage = list.Count > pageSize,
                    TotalRecordsCount = rowsCount ?? list.Count
                },
                Messages = messages,
            };
        }
        public PaginatedAppResponse<T> NotFound<T>(string[] messages = null)
        {
            return new PaginatedAppResponse<T>
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Messages = messages
            };
        }
        public PaginatedAppResponse<T> BadRequest<T>(string[] messages = null)
        {
            return new PaginatedAppResponse<T>
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Messages = messages
            };
        }
        public PaginatedAppResponse<T> Unauthorized<T>(string[] messages = null)
        {
            return new PaginatedAppResponse<T>
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Messages = messages ?? new[] { "Unauthorized" }
            };
        }

        public PaginatedAppResponse<T> InternalServerError<T>(string[] messages = null)
        {
            return new PaginatedAppResponse<T>
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError,
                Messages = messages ?? new[] { "InternalServerError : Contact your administrator!" }
            };
        }
    }
}
