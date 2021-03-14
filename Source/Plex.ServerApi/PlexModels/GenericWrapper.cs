namespace Plex.ServerApi.PlexModels
{
    using System.Text.Json.Serialization;

    public class GenericWrapper<T>
    {
        [JsonPropertyName("MediaContainer")]
        public T Container { get; set; }
    }
}
