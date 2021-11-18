namespace Shared.Results
{
    public class AuthenticateResult
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsCandidate { get; set; }
        public bool IsCompany { get; set; }

    }
}
