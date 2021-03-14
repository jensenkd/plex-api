namespace Plex.Library.ApiModels.Libraries.Filters
{
    using System;
    using Api.PlexModels.Library;
    using Api.PlexModels.Library.Search;

    [Serializable]
    internal class InvalidOperatorException : Exception
    {
        public InvalidOperatorException()
        {
        }

        public InvalidOperatorException(Operator op, FilterField field)
            : base($"{op} is not a valid Operator for {field.Title}")
        {
        }
    }
}
