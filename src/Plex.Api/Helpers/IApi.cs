using System.Threading.Tasks;

namespace Plex.Api.Helpers
{
    public interface IApi
    {
        Task Request(Request request);
        Task<T> Request<T>(Request request);
        Task<string> RequestContent(Request request);
        T DeserializeXml<T>(string receivedString);
    }
}