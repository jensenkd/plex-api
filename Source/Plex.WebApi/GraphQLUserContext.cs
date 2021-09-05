namespace Plex.WebApi
{
    using System.Security.Claims;
    using GraphQL.Authorization;

    /// <summary>
    /// The GraphQL user context for the current request. The user context is accessible in field resolvers and
    /// validation rules using <c>context.UserContext.As&lt;GraphQLUserContext&gt;()</c>.
    /// </summary>
    public class GraphQLUserContext : IProvideClaimsPrincipal
    {
        /// <summary>
        /// Gets or sets the current users claims principal.
        /// </summary>
        public ClaimsPrincipal User { get; set; }
    }
}
