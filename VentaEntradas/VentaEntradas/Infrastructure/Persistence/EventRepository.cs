using VentaEntradas.Core.Application.Interfaces;
using VentaEntradas.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace VentaEntradas.Infrastructure.Persistence
{
    using Core.Application.Interfaces;
    using Core.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace Infrastructure.Persistence
    {
        public class EventRepository : IEventRepository
        {
            private readonly ApplicationDbContext _context;

            public EventRepository(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Event>> GetAllEventsAsync()
            {
                return await _context.Events.ToListAsync();
            }

            public async Task<Event> GetEventByIdAsync(int id)
            {
                return await _context.Events.FindAsync(id);
            }

            public async Task AddEventAsync(Event newEvent)
            {
                _context.Events.Add(newEvent);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateEventAsync(Event eventToUpdate)
            {
                _context.Events.Update(eventToUpdate);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteEventAsync(int id)
            {
                var eventItem = await _context.Events.FindAsync(id);
                if (eventItem != null)
                {
                    eventItem.IsDeleted = true;
                    await _context.SaveChangesAsync();
                }
            }
        }
    }

}
