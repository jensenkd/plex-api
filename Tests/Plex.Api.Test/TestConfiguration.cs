namespace Plex.Api.Test
{
    using ApiModels;

    public class TestConfiguration
    {
        public string Login { get;   }
        public string Password { get; }
        public string AccessToken { get; }
        public ClientOptions ClientOptions { get; }

        public TestConfiguration(string login, string password, string accessToken, ClientOptions clientOptions)
        {
            Login = login;
            Password = password;
            AccessToken = accessToken;
            ClientOptions = clientOptions;
        }
    }
}
