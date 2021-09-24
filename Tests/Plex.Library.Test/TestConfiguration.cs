namespace Plex.Library.Test
{
    public class TestConfiguration
    {
        public string Host { get; }
        public string AuthenticationKey { get; }
        public string Login { get; set; }
        public string Password { get; set; }

        public TestConfiguration(string host, string authenticationKey, string login, string password)
        {
            this.Host = host;
            this.AuthenticationKey = authenticationKey;
            this.Login = login;
            this.Password = password;
        }
    }
}
