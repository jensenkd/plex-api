namespace Plex.WebApi.IntegrationTest.Models
{
    using System.Collections.Generic;

    public class GraphQLResponse
    {
        public GraphQLResponse() => this.Errors = new List<GraphQLError>();

        public List<GraphQLError> Errors { get; }
    }
}
