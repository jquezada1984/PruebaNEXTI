import { Event } from '../types';

const API_BASE_URL = 'https://localhost:44313/api/Event';

export const fetchEvents = async (): Promise<Event[]> => {
  const response = await fetch(API_BASE_URL);
  return response.json();
};

export const fetchEventById = async (id: number): Promise<Event> => {
  const response = await fetch(`${API_BASE_URL}/${id}`);
  return response.json();
};

export const createEvent = async (event: Event): Promise<void> => {
  await fetch(API_BASE_URL, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(event),
  });
};

export const updateEvent = async (id: number, event: Event): Promise<void> => {
  await fetch(`${API_BASE_URL}/${id}`, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(event),
  });
};

export const deleteEvent = async (id: number): Promise<void> => {
  await fetch(`${API_BASE_URL}/${id}`, {
    method: 'DELETE',
  });
};
