namespace Plex.Library
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Api.PlexModels.Library.Search;
    using ApiModels.Libraries.Filters;

    /// <summary>
    /// Class for Mapping Library Filter Model Objects
    /// </summary>
    public static class LibraryFilterMapper
    {
        /// <summary>
        /// Get List of FilterModel objects from Plex FilterContainer object
        /// </summary>
        /// <param name="filterFieldContainer">Plex FilterContainer object from Api</param>
        /// <returns></returns>
        public static List<FilterModel> GetFilterModelsFromFilterContainer(FilterFieldContainer filterFieldContainer)
        {
            var models = new List<FilterModel>();

            var operatorDictionary = filterFieldContainer.FieldMetas
                .FieldTypes.ToDictionary(c => c.Type, c => c.Operators);

            foreach (var fieldType in filterFieldContainer.FieldMetas.Types)
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
                        var fieldMatch = fieldType.Fields.SingleOrDefault(c => c.Key.Contains(field.FilterName));
                        if (fieldMatch == null)
                        {
                            throw new ApplicationException("Where is this field: " + field.FilterName);
                        }

                        var filterField = new FilterFieldModel
                        {
                            Title =  field.Title,
                            Type = field.Type,
                            UriKey = field.Key,
                            FieldKey = field.FilterName,
                            Operators = operatorDictionary[fieldMatch.Type]
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
