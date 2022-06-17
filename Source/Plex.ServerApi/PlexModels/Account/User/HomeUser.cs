namespace Plex.ServerApi.PlexModels.Account.User;

using System.Text.Json.Serialization;

public class HomeUser
{
    /// <summary>
    /// User's Plex account ID.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// User's Plex account UUID.
    /// </summary>
    public string Uuid { get; set; }

    /// <summary>
    /// Seems to be an alias for username.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// User's username.
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// User's email address (user@gmail.com).
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// ???
    /// </summary>
    public string FriendlyName { get; set; }

    /// <summary>
    /// Link to the users avatar.
    /// </summary>
    public string Thumb { get; set; }

    /// <summary>
    /// Does the user have a password
    /// </summary>
    public bool HasPassword { get; set; }

    /// <summary>
    /// Date user was last updated
    /// </summary>
    public long UpdatedAt { get; set; }

    /// <summary>
    /// Is User Account Admin.
    /// </summary>
    [JsonPropertyName("admin")]
    public bool IsAdmin { get; set; }

    /// <summary>
    /// Is User Account Guest.
    /// </summary>
    [JsonPropertyName("guest")]
    public bool IsGuest { get; set; }

    /// <summary>
    /// Is User Account Restricted.
    /// </summary>
    [JsonPropertyName("restricted")]
    public bool IsRestricted { get; set; }

    /// <summary>
    /// Profile if user is restricted
    /// </summary>
    public string RestrictionProfile { get; set; }

    /// <summary>
    /// Unknown (possibly SSL enabled?).
    /// </summary>
    [JsonPropertyName("protected")]
    public bool IsProtected { get; set; }
}
