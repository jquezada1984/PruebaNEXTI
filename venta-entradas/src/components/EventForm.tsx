import React, { useState, useEffect } from 'react';
import { Event } from '../types';
import { useNavigate } from 'react-router-dom';

interface EventFormProps {
  event?: Event;
  onSave: (event: Event) => void;
}

const EventForm: React.FC<EventFormProps> = ({ event, onSave }) => {
  const navigate = useNavigate();

  const [formState, setFormState] = useState<Event>({
    id: event?.id || 0,
    date: event?.date ? event.date.split('T')[0] : '', // Conversión de la fecha al formato adecuado
    place: event?.place || '',
    description: event?.description || '',
    price: event?.price || 0,
  });

  useEffect(() => {
    if (event) {
      setFormState({
        ...event,
        date: event.date ? event.date.split('T')[0] : '', // Conversión de la fecha al formato adecuado
      });
    }
  }, [event]);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    const { name, value } = e.target;
    setFormState({ ...formState, [name]: value });
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    onSave(formState);
    navigate('/'); // Redirigir a la lista de eventos después de guardar
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>
        Fecha del Evento:
        <input type="date" name="date" value={formState.date} onChange={handleChange} required />
      </label>
      <label>
        Lugar:
        <input type="text" name="place" value={formState.place} onChange={handleChange} required />
      </label>
      <label>
        Descripción:
        <textarea name="description" value={formState.description} onChange={handleChange} required />
      </label>
      <label>
        Precio:
        <input type="number" name="price" value={formState.price} onChange={handleChange} required />
      </label>
      <button type="submit">Guardar</button>
    </form>
  );
};

export default EventForm;
