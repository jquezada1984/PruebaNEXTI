import React, { useEffect } from 'react';
import { useNavigate } from 'react-router-dom'; // Importa useNavigate para la navegación
import EventGrid from '../components/EventGrid';
import { useEventStore } from '../stores/useEventStore';

const EventListPage: React.FC = () => {
  const { events, fetchAllEvents, removeEvent } = useEventStore();
  const navigate = useNavigate(); 

  useEffect(() => {
    fetchAllEvents();
  }, [fetchAllEvents]);

  const handleEdit = (id: number) => {
    navigate(`/event/edit/${id}`);
  };

  const handleDelete = (id: number) => {
    removeEvent(id);
  };

  const handleCreate = () => {
    navigate('/event/new'); 
  };

  return (
    <div>
      <h1>Lista de Eventos</h1>
      <button onClick={handleCreate}>Crear Nuevo Evento</button> {  }
      <EventGrid events={events} onEdit={handleEdit} onDelete={handleDelete} />
    </div>
  );
};

export default EventListPage;
