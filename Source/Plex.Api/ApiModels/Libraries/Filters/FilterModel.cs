namespace Plex.Api.ApiModels.Libraries.Filters
{
    using System.Collections.Generic;
    using PlexModels.Library.Search;

    /// <summary>
    /// Filter
    ///  "key": "/library/sections/1/all?type=1",
    ///"type": "movie",
    ///"title": "Movies",
    ///"active": true,
    /// </summary>
    public class FilterModel
    {
        /// <summary>
        /// Type of Filter (Ex: movie, folder)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Url key (ex: /library/sections/1/all?type=1)
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Title for Filter (Ex: Movie, Folder)
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Filter is Active (true/false)
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Filter Fields
        /// </summary>
        public List<FilterFieldModel> FilterFields { get; set; } = new();

        public List<FilterSort> FilterSorts { get; set; } = new();
    }
}
