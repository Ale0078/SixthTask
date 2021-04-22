using SixthTask.Logic.Components.Builders.Interfaces;

namespace SixthTask.Logic.UserInterface.Abstracts
{
    public abstract class Controller
    {
        public View ViewToDisplay { get; }
        public ITicketBuilder TicketCreater { get; protected set; }
        public ILuckyTicketBuilder LuckyTicketCreater { get; protected set; }

        public Controller(View viewToDisplay, ITicketBuilder ticketCreater, ILuckyTicketBuilder luckyTicketCreater) 
        {
            ViewToDisplay = viewToDisplay;
            TicketCreater = ticketCreater;
            LuckyTicketCreater = luckyTicketCreater;
        }

        public abstract int GetCountOfLuckyTicket();
        public abstract void SetTicketCreater(ITicketBuilder ticketCreater);
        public abstract void SetLuckyTicketCreater(ILuckyTicketBuilder luckyTicketCreater);
        public abstract void SetModel();
        public abstract void Display();
    }
}
