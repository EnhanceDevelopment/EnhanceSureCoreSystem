using System.ComponentModel;

namespace EnhanceSure.Domain.Enum {
    public enum ErrorCategory {
        [Description("UNH")]
        UNH = 1,     // for undefined error or unhandled error 
        [Description("TRN")]
        TRN = 2,    // for taransaction errors
        [Description("SYS")]
        SYS=03,      //for system errors
    }
}
