using Microsoft.Extensions.Logging;

namespace Kineticmedia.Plex.Api
{
    public class LoggingEvents
    {
        public static EventId Authentication => new EventId(500);

        public static EventId Api => new EventId(1000);
      
        public static EventId Updater => new EventId(6000);

    }
}