namespace Kineticmedia.Plex.Api.Ombi
{
    public class OmbiSettings
    {
        public string BaseUrl { get; set; }
        public bool CollectAnalyticData { get; set; }
        public bool Set { get; set; }
        public bool Wizard { get; set; }
        public string ApiKey { get; set; }
        public bool IgnoreCertificateErrors { get; set; }
        public bool DoNotSendNotificationsForAutoApprove { get; set; }
        public bool HideRequestsUsers { get; set; }
        public string DefaultLanguageCode { get; set; } = "en";
    }
}