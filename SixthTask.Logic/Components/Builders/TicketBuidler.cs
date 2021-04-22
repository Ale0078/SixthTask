using SixthTask.Logic.Components.Interfaces;
using SixthTask.Logic.Components.Builders.Interfaces;

namespace SixthTask.Logic.Components.Builders
{
    public class TicketBuidler : ITicketBuilder
    {
        public int TicketSize { get; init; }
        public int TicketMinValue { get; init; }
        public int TicketMaxValue { get; init; }

        public TicketBuidler(int ticketMinValue, int ticketMaxValue, int ticketSize) 
        {
            TicketMinValue = ticketMinValue;
            TicketMaxValue = ticketMaxValue;
            TicketSize = ticketSize;
        }

        public ITicket Create() 
        {
            return new Ticket(TicketMinValue, TicketMaxValue, TicketSize);
        }
    }
}
