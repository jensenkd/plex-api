namespace Plex.Api.Models.PlexAdd
{
    /// <summary>
    /// Plex Add Wrapper
    /// </summary>
    public class PlexAddWrapper
    {
        /// <summary>
        /// Add
        /// </summary>
        public PlexAdd Add { get; set; }

        /// <summary>
        /// Error
        /// </summary>
        public AddUserError Error { get; set; }

        /// <summary>
        /// Has Error?
        /// </summary>
        public bool HasError => this.Error != null;
    }
}
