﻿namespace Task_Fullstack_Developer.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "Open";
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
