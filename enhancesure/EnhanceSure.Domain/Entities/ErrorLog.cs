using EnhanceSure.Domain.Common;

namespace EnhanceSure.Domain.Entities {
    public class ErrorLog: BaseEntity {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public string UserName { get; set; } = "Annonimous";
    }
}
