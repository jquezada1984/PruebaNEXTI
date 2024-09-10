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
                var events = new List<Event>();

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.OpenAsync(); // Abre la conexión

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "sp_GetAllEvents";  // Nombre del procedimiento almacenado
                        command.CommandType = System.Data.CommandType.StoredProcedure;  // Indica que es un SP

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var eventItem = new Event
                                {
                                    Id = reader.GetInt32(0),  // Mapea las columnas devueltas
                                    Date = reader.GetDateTime(1),
                                    Place = reader.IsDBNull(2) ? null : reader.GetString(2),
                                    Description = reader.IsDBNull(3) ? null : reader.GetString(3),
                                    Price = reader.GetDecimal(4),
                                    IsDeleted = reader.GetBoolean(5)
                                };

                                events.Add(eventItem);  // Agrega el evento a la lista
                            }
                        }
                    }
                }

                return events;  // Retorna la lista de eventos
            }

            public async Task<Event> GetEventByIdAsync(int id)
            {
                Event eventItem = null;

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.OpenAsync();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "sp_GetEventById";  // Nombre del procedimiento almacenado
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Agrega el parámetro de entrada
                        var parameter = command.CreateParameter();
                        parameter.ParameterName = "@Id";
                        parameter.Value = id;
                        command.Parameters.Add(parameter);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                eventItem = new Event
                                {
                                    Id = reader.GetInt32(0),
                                    Date = reader.GetDateTime(1),
                                    Place = reader.IsDBNull(2) ? null : reader.GetString(2),
                                    Description = reader.IsDBNull(3) ? null : reader.GetString(3),
                                    Price = reader.GetDecimal(4),
                                    IsDeleted = reader.GetBoolean(5)
                                };
                            }
                        }
                    }
                }

                return eventItem;  // Retorna el evento o null si no se encontró
            }
        

            public async Task AddEventAsync(Event newEvent)
            {
                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.OpenAsync();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "sp_InsertEvent";  // Nombre del procedimiento almacenado
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Agrega los parámetros necesarios
                        var dateParam = command.CreateParameter();
                        dateParam.ParameterName = "@Date";
                        dateParam.Value = newEvent.Date;
                        command.Parameters.Add(dateParam);

                        var placeParam = command.CreateParameter();
                        placeParam.ParameterName = "@Place";
                        placeParam.Value = (object)newEvent.Place ?? DBNull.Value;
                        command.Parameters.Add(placeParam);

                        var descriptionParam = command.CreateParameter();
                        descriptionParam.ParameterName = "@Description";
                        descriptionParam.Value = (object)newEvent.Description ?? DBNull.Value;
                        command.Parameters.Add(descriptionParam);

                        var priceParam = command.CreateParameter();
                        priceParam.ParameterName = "@Price";
                        priceParam.Value = newEvent.Price;
                        command.Parameters.Add(priceParam);

                        // Ejecuta el procedimiento
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }

            public async Task UpdateEventAsync(Event eventToUpdate)
            {
                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.OpenAsync();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "sp_UpdateEvent";  // Nombre del procedimiento almacenado
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Agrega los parámetros necesarios
                        var idParam = command.CreateParameter();
                        idParam.ParameterName = "@Id";
                        idParam.Value = eventToUpdate.Id;
                        command.Parameters.Add(idParam);

                        var dateParam = command.CreateParameter();
                        dateParam.ParameterName = "@Date";
                        dateParam.Value = eventToUpdate.Date;
                        command.Parameters.Add(dateParam);

                        var placeParam = command.CreateParameter();
                        placeParam.ParameterName = "@Place";
                        placeParam.Value = (object)eventToUpdate.Place ?? DBNull.Value;
                        command.Parameters.Add(placeParam);

                        var descriptionParam = command.CreateParameter();
                        descriptionParam.ParameterName = "@Description";
                        descriptionParam.Value = (object)eventToUpdate.Description ?? DBNull.Value;
                        command.Parameters.Add(descriptionParam);

                        var priceParam = command.CreateParameter();
                        priceParam.ParameterName = "@Price";
                        priceParam.Value = eventToUpdate.Price;
                        command.Parameters.Add(priceParam);

                        // Ejecuta el procedimiento
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }

            public async Task DeleteEventAsync(int id)
            {
                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.OpenAsync();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "sp_DeleteEvent";  // Nombre del procedimiento almacenado
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Agrega el parámetro de entrada
                        var idParam = command.CreateParameter();
                        idParam.ParameterName = "@Id";
                        idParam.Value = id;
                        command.Parameters.Add(idParam);

                        // Ejecuta el procedimiento
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
        }
    }

}
