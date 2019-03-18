namespace Voting.Web.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;

    public interface IRepository
    {
        void AddEvent(Event @event);

        Event GetEvent(int id);

        IEnumerable<Event> GetEvents();

        bool ProductExists(int id);

        void RemoveEvent(Event @event);

        Task<bool> SaveAllAsync();

        void UpdateEvent(Event @event);
    }
}