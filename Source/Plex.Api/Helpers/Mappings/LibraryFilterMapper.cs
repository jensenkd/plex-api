namespace Plex.Api.Helpers.Mappings
{
    using System.Collections.Generic;
    using System.Linq;
    using ApiModels.Libraries.Filters;
    using PlexModels.Library.Search;

    /// <summary>
    /// Class for Mapping Library Filter Model Objects
    /// </summary>
    public static class LibraryFilterMapper
    {
        /// <summary>
        /// Get List of FilterModel objects from Plex FilterContainer object
        /// </summary>
        /// <param name="filterContainer">Plex FilterContainer object from Api</param>
        /// <returns></returns>
        public static List<FilterModel> GetFilterModelsFromFilterContainer(FilterContainer filterContainer)
        {
            var models = new List<FilterModel>();

            var operatorDictionary = filterContainer.FieldMetas
                .FieldTypes.ToDictionary(c => c.Type, c => c.Operators);

            foreach (var fieldType in filterContainer.FieldMetas.Types)
            {
                var filterModel = new FilterModel
                {
                    Title = fieldType.Title,
                    Type = fieldType.FieldType,
                    Active = fieldType.Active,
                    Key = fieldType.Key,
                    FilterSorts = fieldType.Sorts
                };

                if (fieldType.Filters != null && fieldType.Filters.Any())
                {
                    foreach (var field in fieldType.Filters)
                    {
                        var filterField = new FilterFieldModel
                        {
                            Title =  field.Title,
                            Type = field.Type,
                            UriKey = field.Key,
                            FieldKey = field.FilterName,
                            Operators = operatorDictionary[field.FilterType]
                        };
                        filterModel.FilterFields.Add(filterField);
                    }
                }

                models.Add(filterModel);
            }

            return models;
        }
    }
}
