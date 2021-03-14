namespace Plex.ServerApi.Test
{

    public class TestConfiguration
    {
        public string Login { get;   }
        public string Password { get; }
        public string AccessToken { get; }
        public ClientOptions ClientOptions { get; }

        public TestConfiguration(string login, string password, string accessToken, ClientOptions clientOptions)
        {
            this.Login = login;
            this.Password = password;
            this.AccessToken = accessToken;
            this.ClientOptions = clientOptions;
        }
    }
}
