using EnhanceSure.Domain.Common;
using EnhanceSure.Domain.Enum;

namespace EnhanceSure.Domain.Entities {
    public class InterviewSchedule:BaseEntity {
        public Guid Interviewer { get; set; }
        public Guid Interviewee { get; set; }
        public DateTime InterviewDateTime { get; set; }
        public InterviewStatus Status { get; set; }
        public int RemainingDays { 
            get {
                if(InterviewDateTime> DateTime.Now)
                {
                    return (int)(InterviewDateTime -DateTime.Now).TotalDays;
                }
                return 0;
            }
        }
    }
}
