using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Fullstack_Developer.Controller;
using Task_Fullstack_Developer.Context;
using Task_Fullstack_Developer.Models;
using Xunit;

namespace Task_Fullstack_Developer.Tests
{
    public class TicketControllerTests
    {
        private readonly TicketController _controller;
        private readonly TicketContext _context;

        public TicketControllerTests()
        {
            var options = new DbContextOptionsBuilder<TicketContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new TicketContext(options);
            _controller = new TicketController(_context);
        }

        [Fact]
        public async Task GetTicketsFunctions_ReturnsOkResult_WithListOfTempTickets()
        {
            // Arrange
            _context.Tickets.Add(new Ticket { TicketId = 1, Description = "Test Ticket 1", Status = "Open", Date = DateTime.Now });
            _context.Tickets.Add(new Ticket { TicketId = 2, Description = "Test Ticket 2", Status = "Closed", Date = DateTime.Now });
            await _context.SaveChangesAsync();

            // Act
            var result = await _controller.GetTickets();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Ticket>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var tickets = Assert.IsAssignableFrom<IEnumerable<Ticket>>(okResult.Value);
            Assert.Equal(2, tickets.Count());
        }

        [Fact]
        public async Task GetAndCheckTicket_ValidId_ReturnsOkResult_WithTicket()
        {
            // Arrange
            var ticket = new Ticket { TicketId = 1, Description = "Test Ticket", Status = "Open", Date = DateTime.Now };
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            // Act
            var result = await _controller.GetTicket(1);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Ticket>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnedTicket = Assert.IsType<Ticket>(okResult.Value);
            Assert.Equal(ticket.TicketId, returnedTicket.TicketId);
        }


        [Fact]
        public async Task CreateTicket_ValidTicket_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var newTicket = new Ticket { Description = "New Ticket description", Status = "Open", Date = DateTime.Now };

            // Act
            var result = await _controller.CreateTicket(newTicket);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Ticket>>(result);
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var returnedTicket = Assert.IsType<Ticket>(createdAtActionResult.Value);
            Assert.Equal(newTicket.Description, returnedTicket.Description);
        }

        [Fact]
        public async Task UpdateTicket_ValidId_UpdatesTicket()
        {
            // Arrange
            var existingTicket = new Ticket { TicketId = 1, Description = "Existing Ticket", Status = "Open", Date = DateTime.Now };
            _context.Tickets.Add(existingTicket);
            await _context.SaveChangesAsync();

            var updatedTicket = new Ticket { TicketId = 1, Description = "Updated Ticket", Status = "Closed", Date = DateTime.Now };

            // Act
            var result = await _controller.UpdateTicket(1, updatedTicket);

            // Assert
            Assert.IsType<NoContentResult>(result);
            var ticketFromDb = await _context.Tickets.FindAsync(1);
            Assert.Equal("Updated Ticket", ticketFromDb.Description);
            Assert.Equal("Closed", ticketFromDb.Status);
        }

        [Fact]
        public async Task DeleteTicket_ValidId_ReturnsNoContent()
        {
            // Arrange
            var ticket = new Ticket { TicketId = 1, Description = "Test Ticket", Status = "Open", Date = DateTime.Now };
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            // Act
            var result = await _controller.DeleteTicket(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
            Assert.Null(await _context.Tickets.FindAsync(1));
        }
    }
}
