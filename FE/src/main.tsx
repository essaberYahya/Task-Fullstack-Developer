// src/main.tsx
import React from 'react';
import ReactDOM from 'react-dom/client'; // Ensure this is imported correctly
import TicketTable from './TicketTable';
import 'bootstrap/dist/css/bootstrap.min.css'; // Import Bootstrap
import './App.css'
// Get the root element from index.html
const root = ReactDOM.createRoot(
    document.getElementById('root') as HTMLElement
);

// Render the App component
root.render(
    <React.StrictMode>
        <TicketTable />
    </React.StrictMode>
);
