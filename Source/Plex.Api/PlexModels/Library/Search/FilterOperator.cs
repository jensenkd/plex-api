namespace Plex.Api.PlexModels.Library.Search
{
    using System;
    using System.Text.Json.Serialization;

    public class FilterOperator
    {
        public Operator Type
        {
            get
            {
                switch (this.Key)
                {
                    case "=":
                        return Operator.Is;
                    case "!=":
                        return Operator.IsNot;
                    case ">>":
                        return Operator.GreaterThan;
                    case "<<":
                        return Operator.LessThan;
                    case "==":
                        return Operator.Contains;
                    case "!==":
                        return Operator.NotContains;
                    case "<=":
                        return Operator.BeginsWith;
                    case ">=":
                        return Operator.EndsWith;
                    default:
                        throw new ApplicationException("Non-Mapped Operator: " + this.Key);
                }
            }
        }

        /// <summary>
        /// Key for the Operator (ex: =, !=, >).
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        /// Title for the Operator (ex: is, is not)
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
