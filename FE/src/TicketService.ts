import axios from 'axios';
import { Ticket } from './Tickets';

const API_URL = 'http://127.0.0.1:8000/api/ticket';

export const getTickets = async () => {
    const response = await axios.get<Ticket[]>(API_URL);
    return response.data;
};

export const createTicket = async (ticket: Omit<Ticket, 'ticketId'>) => {
    await axios.post(API_URL, ticket);
};

export const updateTicket = async (id: number, ticket: Ticket) => {
    await axios.put(`${API_URL}/${id}`, ticket);
};

export const deleteTicket = async (id: number) => {
    await axios.delete(`${API_URL}/${id}`);
};
