namespace EnhanceSure.Persistance.DbContexts {
    public class PersistanceConstants {
        public class Tables {
            public const string tblInterviewee = "tbl_Interviewees";
            public const string tblInterviewer = "tbl_Interviewers";
            public const string tblUser = "tbl_Users";
            public const string tblRole = "tbl_Roles";
            public const string tblUserRole = "tbl_UserRoles";
            public const string tblInterviewSchedule = "tbl_InterviewSchedules";
            public const string sysErrorLog = "sys_ErrorLog";

        }
        public class Views {
            public const string vwInterviewShift = "vw_InterviewShifts";

        }
        public class StoreProcedure {
            public const string spXXX = "Sp_XXX";          //for test
        }
    }
}
