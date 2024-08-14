import React from 'react';
import { useParams } from 'react-router-dom';
import EventForm from '../components/EventForm';
import { useEventStore } from '../stores/useEventStore';
import { Event } from '../types';

const EventFormPage: React.FC = () => {
    const { id } = useParams<{ id: string }>();
  const { addEvent, editEvent, events } = useEventStore();

  const eventToEdit = id ? events.find((event) => event.id === parseInt(id, 10)) : undefined;

  const handleSave = async (event: Event) => {
    if (id && eventToEdit) {
      await editEvent(parseInt(id, 10), event);
    } else {
      await addEvent(event);
    }
    // Lógica para navegar de vuelta a la lista o mostrar un mensaje de éxito
  };

  return (
    <div>
      <h1>{id ? 'Editar Evento' : 'Crear Evento'}</h1>
      <EventForm event={eventToEdit} onSave={handleSave} />
    </div>
  );
};

export default EventFormPage;
