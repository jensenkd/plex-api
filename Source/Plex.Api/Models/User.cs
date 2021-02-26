namespace Plex.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Helpers;

    /// <summary>
    /// Plex Account Object
    /// </summary>
    public class PlexAccount
    {
        /// <summary>
        /// User
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; set; }
    }

    /// <summary>
    /// Attributes:
    /// SIGNIN (str): 'https://plex.tv/users/sign_in.xml'
    ///     key (str): 'https://plex.tv/users/account.json'
    ///     authenticationToken (str): Unknown.
    ///     certificateVersion (str): Unknown.
    ///     cloudSyncDevice (str): Unknown.
    ///     email (str): Your current Plex email address.
    ///     entitlements (List&lt;str&gt;): List of devices your allowed to use with this account.
    ///     guest (bool): Unknown.
    ///     home (bool): Unknown.
    ///     homeSize (int): Unknown.
    ///     id (str): Your Plex account ID.
    ///     locale (str): Your Plex locale
    ///     mailing_list_status (str): Your current mailing list status.
    ///     maxHomeSize (int): Unknown.
    ///     queueEmail (str): Email address to add items to your `Watch Later` queue.
    ///     queueUid (str): Unknown.
    ///     restricted (bool): Unknown.
    ///     roles: (List&lt;str&gt;) Lit of account roles. Plexpass membership listed here.
    ///     scrobbleTypes (str): Description
    ///     secure (bool): Description
    ///     subscriptionActive (bool): True if your subsctiption is active.
    ///     subscriptionFeatures: (List&lt;str&gt;) List of features allowed on your subscription.
    ///     subscriptionPlan (str): Name of subscription plan.
    ///     subscriptionStatus (str): String representation of `subscriptionActive`.
    ///     thumb (str): URL of your account thumbnail.
    ///     title (str): Unknown. - Looks like an alias for `username`.
    ///     username (str): Your account username.
    ///     uuid (str): Unknown.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="confirmedAt">Date Conirmed</param>
        public User(DateTime? confirmedAt) => this.ConfirmedAt = confirmedAt;

        /// <summary>
        /// User Id
        /// </summary>
        [JsonConverter(typeof(IntValueConverter))]
        public int Id { get; set; }

        /// <summary>
        /// Email Address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User Unique Id
        /// </summary>
        public string Uuid { get; set; }

        /// <summary>
        /// Joined Date
        /// </summary>
        [JsonPropertyName("joined_at")]
        public DateTime JoinedAt { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Thumbnail
        /// </summary>
        public string Thumb { get; set; }

        /// <summary>
        /// Has Password?
        /// </summary>
        public bool HasPassword { get; set; }

        /// <summary>
        /// Authentication Token
        /// </summary>
        [JsonPropertyName("authentication_token")]
        public string AuthenticationToken { get; set; }

        /// <summary>
        /// Confirmed Date
        /// </summary>
        public DateTime? ConfirmedAt { get; set; }

        /// <summary>
        /// Plex.tv Forum Id
        /// </summary>
        public int? ForumId { get; set; }

        /// <summary>
        /// Remember Me?
        /// </summary>
        public bool RememberMe { get; set; }

        /// <summary>
        /// Subscription Object
        /// </summary>
        [JsonPropertyName("subscription")]
        public Subscription Subscription { get; set; }

        /// <summary>
        /// Roles
        /// </summary>
        [JsonPropertyName("roles")]
        public UserRole Roles { get; set; }

        /// <summary>
        /// Entitlements
        /// </summary>
        [JsonPropertyName("entitlements")]
        public List<string> Entitlements { get; set; }
    }
}
