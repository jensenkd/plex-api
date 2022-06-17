namespace Plex.ServerApi.PlexModels.Account.User;

using System.Collections.Generic;
using System.Text.Json.Serialization;

public class HomeUserContainer
{
    public int Id { get; set; }
    public string Name { get; set; }

    [JsonPropertyName(("guestUserID"))]
    public int GuestUserId { get; set; }

    [JsonPropertyName(("guestUserUUID"))]
    public string GuestUserUuid { get; set; }

    public bool GuestEnabled { get; set; }
    public bool Subscription { get; set; }

    public List<HomeUser> Users { get; set; }
}
