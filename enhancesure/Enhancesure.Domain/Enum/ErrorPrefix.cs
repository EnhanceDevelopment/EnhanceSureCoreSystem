using System.ComponentModel;

namespace EnhanceSure.Domain.Enum {
    public enum ErrorPrefix {
        [Description("XXX")]
        XXX =0,     // for undefined error or unhandled error 
        [Description("TRN")]
        TRN = 1,    // for taransaction errors
        [Description("SYS")]
        SYS=2,      //for system errors
    }
}
