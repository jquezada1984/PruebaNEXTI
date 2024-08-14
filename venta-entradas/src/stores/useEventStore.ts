import create from 'zustand';
import { Event } from '../types';
import { fetchEvents, createEvent, updateEvent, deleteEvent } from '../services/api';

interface EventStore {
  events: Event[];
  fetchAllEvents: () => Promise<void>;
  addEvent: (event: Event) => Promise<void>;
  editEvent: (id: number, event: Event) => Promise<void>;
  removeEvent: (id: number) => Promise<void>;
}

export const useEventStore = create<EventStore>((set) => ({
  events: [],
  fetchAllEvents: async () => {
    const events = await fetchEvents();
    set({ events });
  },
  addEvent: async (event: Event) => {
    await createEvent(event);
    set((state) => ({ events: [...state.events, event] }));
  },
  editEvent: async (id: number, event: Event) => {
    await updateEvent(id, event);
    set((state) => ({
      events: state.events.map((e) => (e.id === id ? event : e)),
    }));
  },
  removeEvent: async (id: number) => {
    await deleteEvent(id);
    set((state) => ({
      events: state.events.filter((e) => e.id !== id),
    }));
  },
}));
