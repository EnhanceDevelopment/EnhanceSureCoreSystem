using System.ComponentModel.DataAnnotations;

namespace EnhanceSure.Domain.Enums;
public enum InterviewStatus {
    [Display(Name="Canceled",Description="Canceled")]
    Canceled = 0,
    [Display(Name = "Delayed", Description = "Delayed")]
    Delayed = 1,
    [Display(Name = "Success", Description = "Success")]
    Success = 2,
}