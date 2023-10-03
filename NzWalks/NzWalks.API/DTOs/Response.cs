namespace NzWalks.API.DTOs
{
    public class Response
    {
        public Guid Id { get; set; }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
