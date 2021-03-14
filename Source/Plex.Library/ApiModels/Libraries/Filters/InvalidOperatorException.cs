namespace Plex.Library.ApiModels.Libraries.Filters
{
    using System;
    using ServerApi.PlexModels.Library;
    using ServerApi.PlexModels.Library.Search;

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
