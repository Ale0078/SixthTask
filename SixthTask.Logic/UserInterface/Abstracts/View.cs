using SixthTask.Logic.Components.Interfaces;

namespace SixthTask.Logic.UserInterface.Abstracts
{
    public abstract class View
    {
        public virtual ITicket TikectToGetTikcets { get; set; }
        public virtual ILuckyTicket LuckyTicketToCheckLucky { get; set; }

        public abstract void Display(int countOfLuckyTicket);
    }
}