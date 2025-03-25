namespace NavOnlineSzamlaUploaderRestApi
{
    public class TokenExchangeRequest
    {
        public string user { get; set; }
        public string password { get; set; }
        public string taxNumber { get; set; }
        public string requestId { get; set; }
        public string timestamp { get; set; }
        public string signature { get; set; }
    }

}
