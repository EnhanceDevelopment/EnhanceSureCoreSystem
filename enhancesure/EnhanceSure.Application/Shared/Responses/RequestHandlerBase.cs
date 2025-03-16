using EnhanceSure.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace EnhanceSure.Application.Shared.Responses {
    public class RequestHandlerBase {
        private readonly IServiceProvider _serviceProvider;

        protected RequestHandlerBase()
        {

        }

        protected RequestHandlerBase(IServiceProvider serviceProvider)
        {
            _serviceProvider=serviceProvider;
        }

        protected IDbConnection createconnection()
        {
            if(_serviceProvider==null)
            {
                throw new InvalidOperationException("requesthandlerbase needs to be initialed with iserviceprovider in order to request this feature");
            }
            var factory = _serviceProvider.GetService<IDbConnectionFactory>();
            return factory?.CreateConnection();
        }

        public AppResponse<T> Ok<T>(T data, string[] messages = null)
        {
            return new AppResponse<T>
            {
                StatusCode=System.Net.HttpStatusCode.OK,
                Data=data,
                Messages=messages??new[] { "Success" }
            };
        }
        public AppResponse<T> BadRequest<T>(T data, string[] messages = null)
        {
            return new AppResponse<T>
            {
                StatusCode=System.Net.HttpStatusCode.BadRequest,
                Data=data,
                Messages=messages??new[] { "Bad Request." }
            };
        }
        public AppResponse<T> NotFound<T>(T data, string[] messages = null)
        {
            return new AppResponse<T>
            {
                StatusCode=System.Net.HttpStatusCode.NotFound,
                Data=data,
                Messages=messages??new[] { "Not Found." }
            };
        }

        public PaginatedAppResponse<T> Ok<T>(IEnumerable<T> data, int pageIndex, int pageSize, int? rowsCount = null, string[] messages = null)
        {
            var list = data.ToList();
            return new PaginatedAppResponse<T>
            {
                StatusCode=System.Net.HttpStatusCode.OK,
                Data=new PaginatedAppResponse<T>.PaginatedWrapper
                {
                    Items=list.Take(pageSize).ToList(),
                    HasNextPage=list.Count>pageSize,
                    TotalRecordsCount=rowsCount??list.Count
                },
                Messages=messages??new[] { "Success" },
            };
        }
        public PaginatedAppResponse<T> NotFound<T>(string[] messages = null)
        {
            return new PaginatedAppResponse<T>
            {
                StatusCode=System.Net.HttpStatusCode.NotFound,
                Messages=messages??new[] { "Not Found" }
            };
        }
        public PaginatedAppResponse<T> BadRequest<T>(string[] messages = null)
        {
            return new PaginatedAppResponse<T>
            {
                StatusCode=System.Net.HttpStatusCode.BadRequest,
                Messages=messages??new[] { "Bad Request" }
            };
        }
        public PaginatedAppResponse<T> Unauthorized<T>(string[] messages = null)
        {
            return new PaginatedAppResponse<T>
            {
                StatusCode=System.Net.HttpStatusCode.Unauthorized,
                Messages=messages??new[] { "Unauthorized" }
            };
        }

        public PaginatedAppResponse<T> InternalServerError<T>(string[] messages = null)
        {
            return new PaginatedAppResponse<T>
            {
                StatusCode=System.Net.HttpStatusCode.InternalServerError,
                Messages=messages??new[] { "InternalServerError : Contact your administrator!" }
            };
        }
    }
}
