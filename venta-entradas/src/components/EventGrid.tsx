import React from 'react';

interface Event {
  id: number;
  date: string;
  place: string;
  description: string;
  price: number;
}

interface EventGridProps {
  events: Event[];
  onEdit: (id: number) => void;
  onDelete: (id: number) => void;
}

const EventGrid: React.FC<EventGridProps> = ({ events, onEdit, onDelete }) => {
  return (
    <table>
      <thead>
        <tr>
          <th>Fecha</th>
          <th>Lugar</th>
          <th>Descripción</th>
          <th>Precio</th>
          <th>Acciones</th>
        </tr>
      </thead>
      <tbody>
        {events.map((event) => (
          <tr key={event.id}>
            <td>{event.date}</td>
            <td>{event.place}</td>
            <td>{event.description}</td>
            <td>{event.price}</td>
            <td>
              <button onClick={() => onEdit(event.id)}>Editar</button>
              <button onClick={() => onDelete(event.id)}>Eliminar</button>
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default EventGrid;
