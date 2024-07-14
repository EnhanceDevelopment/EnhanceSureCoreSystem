namespace BindraSawMill.Application.Shared.Responses {
    public class BaseCommandResponse {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
