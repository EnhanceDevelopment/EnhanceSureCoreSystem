using EnhanceSure.Application.DTOs.Common;
namespace EnhanceSure.Application.DTOs.Interviewees {
    public class IntervieweeDto: BaseDto {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
    }
}
