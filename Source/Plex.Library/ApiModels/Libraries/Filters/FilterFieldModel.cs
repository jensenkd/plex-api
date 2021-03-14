namespace Plex.Library.ApiModels.Libraries.Filters
{
    using System.Collections.Generic;
    using ServerApi.PlexModels.Library.Search;

    /// <summary>
    /// Filter Field
    /// </summary>
    public class FilterFieldModel
    {
        /// <summary>
        /// Title of Filter Field (Ex: Genre)
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Url key (Ex: /library/sections/1/genre)
        /// </summary>
        public string UriKey { get; set; }

        /// <summary>
        /// Filter Field Type (Ex: tag, string, integer)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Filter Field Key (Ex: genre, year)
        /// </summary>
        public string FieldKey { get; set; }

        /// <summary>
        /// Operators available for this field
        /// </summary>
        public List<FilterOperator> Operators { get; set; }
    }
}
