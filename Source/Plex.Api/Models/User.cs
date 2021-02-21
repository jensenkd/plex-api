namespace Plex.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Plex.Api.Helpers;

    /// <summary>
    ///
    /// </summary>
    public class PlexAccount
    {
        /// <summary>
        ///
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
        /// <param name="confirmedAt"></param>
        public User(DateTime? confirmedAt) => this.ConfirmedAt = confirmedAt;

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(IntValueConverter))]
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Uuid { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("joined_at")]
        public DateTime JoinedAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Thumb { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool HasPassword { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("authentication_token")]
        public string AuthenticationToken { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime? ConfirmedAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int? ForumId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool RememberMe { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("subscription")]
        public Subscription Subscription { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("roles")]
        public UserRole Roles { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("entitlements")]
        public List<string> Entitlements { get; set; }
    }
}
