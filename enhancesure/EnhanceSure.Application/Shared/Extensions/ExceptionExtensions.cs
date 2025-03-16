using System;
using System.Text;

namespace Application.Shared.Extensions {
    public static class ExceptionExtensions {
        public static string Flatten(this Exception exception) {
            var stringBuilder = new StringBuilder();
            while (exception != null) {
                stringBuilder.AppendLine(exception.Message);
                stringBuilder.AppendLine(exception.TargetSite?.Name);
                stringBuilder.AppendLine(exception.StackTrace);

                exception = exception.InnerException;
            }
            return stringBuilder.ToString();
        }

    }
}
