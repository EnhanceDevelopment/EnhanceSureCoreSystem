using BindraSawMill.Application.Shared.Responses;
using MediatR;

namespace BindraSawMill.Application.Shared.Request {
    public interface IAppRequest<out T>: IRequest<T> {
        //public AuditUser UpdatedBy { get; set; }
        public Menu Menu { get; set; }
    }

    public class AppRequest<T>: IAppRequest<AppResponse<T>> {
        public Guid Id { get; set; }
        //public AuditUser UpdatedBy { get; set; } = new AuditUser
        //{
        //    Id = Guid.Empty,
        //    UserName = "Anonymous",
        //    UserType = 1,
        //    DateTime = DateTime.UtcNow
        //};
        public Menu Menu { get; set; } = new Menu();

        //public bool HasAuthorizationClaims => this.UpdatedBy != null;
    }

    public class Menu {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
