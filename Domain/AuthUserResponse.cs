using System.Collections.Generic;

namespace firstTUT.Domain
{
    public class AuthUserResponse
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}