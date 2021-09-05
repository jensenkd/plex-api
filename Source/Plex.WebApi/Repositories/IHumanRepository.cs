namespace Plex.WebApi.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Plex.WebApi.Models;

    public interface IHumanRepository
    {
        IObservable<Human> WhenHumanCreated { get; }

        Task<Human> AddHumanAsync(Human human, CancellationToken cancellationToken);

        Task<List<Character>> GetFriendsAsync(Human human, CancellationToken cancellationToken);

        Task<Human> GetHumanAsync(Guid id, CancellationToken cancellationToken);
    }
}
