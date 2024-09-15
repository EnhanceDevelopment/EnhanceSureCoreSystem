using System.Net;

namespace EnhanceSure.Application.Shared.Responses {
    public interface IAppResponse {
        public HttpStatusCode StatusCode { get; set; }
        public string[] Messages { get; set; }

    }
    public class AppResponse<T>: IAppResponse {
        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; }
        public string[] Messages { get; set; }
    }
}
