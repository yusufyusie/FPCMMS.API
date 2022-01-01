namespace FPCMMS.Application.DTOs
{
    public class AuthenticationResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Country { get; set; }
        public string Token { get; set; }
        public DateTimeOffset Expiration { get; set; }
    }
}