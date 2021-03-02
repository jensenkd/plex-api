namespace Plex.Api.PlexModels
{
    using System.Text.Json.Serialization;
    using Server.Releases;

    public class GenericWrapper<T>
    {
        [JsonPropertyName("MediaContainer")]
        public T Container { get; set; }
    }
}
