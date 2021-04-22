using NLog;

using SixthTask.Logic.Components.Builders.Interfaces;
using SixthTask.Logic.UserInterface.Abstracts;

namespace SixthTask.Controllers
{
    public class LuckyTicketController : Controller
    {
        private readonly ILogger _logger;

        public LuckyTicketController(View viewToDisplay, ITicketBuilder ticketCreater, ILuckyTicketBuilder luckyTicketCreater) :
            base(viewToDisplay, ticketCreater, luckyTicketCreater)
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public override void Display()
        {
            ViewToDisplay.Display(GetCountOfLuckyTicket());

            _logger.Info("Info was outputted into console");
        }

        public override int GetCountOfLuckyTicket()
        {
            int countOfLuckyTicket = 0;

            foreach (var ticket in ViewToDisplay.TikectToGetTikcets)
            {
                if (ViewToDisplay.LuckyTicketToCheckLucky.IsLuckyTicket(ticket))
                {
                    countOfLuckyTicket++;
                }
            }

            _logger.Info("Lucky ticket was counted");

            return countOfLuckyTicket;
        }

        public override void SetLuckyTicketCreater(ILuckyTicketBuilder luckyTicketCreater)
        {
            LuckyTicketCreater = luckyTicketCreater;

            _logger.Info("New Lucky ticket creater was setted");
        }

        public override void SetModel()
        {
            ViewToDisplay.TikectToGetTikcets = TicketCreater.Create();
            ViewToDisplay.LuckyTicketToCheckLucky = LuckyTicketCreater.Create();

            _logger.Info("Model to view was setted");
        }

        public override void SetTicketCreater(ITicketBuilder ticketCreater)
        {
            TicketCreater = ticketCreater;

            _logger.Info("New Ticket creater was setted");
        }
    }
}
