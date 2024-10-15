import React, { useEffect, useState } from 'react';
import { Ticket } from './Tickets';
import { getTickets, createTicket, updateTicket, deleteTicket } from './TicketService';

const TicketTable: React.FC = () => {
    const [tickets, setTickets] = useState<Ticket[]>([]);
    const [newTicket, setNewTicket] = useState<Omit<Ticket, 'ticketId'>>({
        description: '',
        status: 'Open',
        date: new Date().toISOString(),
    });

    const fetchTickets = async () => {
        const data = await getTickets();
        setTickets(data);
    };

    useEffect(() => {
        fetchTickets();
    }, []);

    const handleCreate = async () => {
        await createTicket(newTicket);
        fetchTickets();
        setNewTicket({ description: '', status: 'Open', date: new Date().toISOString() });
    };

    const handleUpdate = async (ticket: Ticket) => {
        await updateTicket(ticket.ticketId, ticket);
        fetchTickets();
    };

    const handleDelete = async (id: number) => {
        await deleteTicket(id);
        fetchTickets();
    };

    return (
        <div className= "container mt-5" >
            < table className = "table" >
                <thead>
                <tr>
                <th>ID </th>
                < th > Description </th>
                < th > Status </th>
                < th > Date </th>
                < th > Actions </th>
                </tr>
                </thead>
                <tbody>
    {
        tickets.map((ticket) => (
            <tr key= { ticket.ticketId } >
            <td>{ ticket.ticketId } </td>
            < td >
            <input
                        type="text"
                        className="form-input"
                  value = { ticket.description }
                  onChange = {(e) =>
                setTickets((prev) =>
                    prev.map((t) =>
                        t.ticketId === ticket.ticketId ? { ...t, description: e.target.value } : t
                    )
                )
                  }
                />
    </td>
    < td >
                    <select
    className="form-input"
                  value={ ticket.status }
onChange = {(e) =>
setTickets((prev) =>
    prev.map((t) =>
        t.ticketId === ticket.ticketId ? { ...t, status: e.target.value } : t
    )
)
                  }
                >
    <option value="Open" > Open </option>
        < option value = "Closed" > Closed </option>
            </select>
            </td>
            < td > { new Date(ticket.date).toLocaleDateString() } </td>
            < td >
            <a href="#" className="me-2 " onClick = {() => handleUpdate(ticket)}>
                Update
                </a>
                <a href="#" onClick = {() => handleDelete(ticket.ticketId)}>
                    Delete
                    </a>
                    </td>
                    </tr>
          ))}
</tbody>
    </table>

 
        < div className = "mb-3 MT-2" >
            <input
          type="text"
className = "form-control"
placeholder = "Description"
value = { newTicket.description }
onChange = {(e) => setNewTicket({ ...newTicket, description: e.target.value })}
        />
    </div>
    < button className = "btn btn-success" onClick = { handleCreate } >
        Add New Ticket
            </button>
            </div>
  );
};

export default TicketTable;
