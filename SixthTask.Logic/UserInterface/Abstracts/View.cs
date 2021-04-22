using SixthTask.Logic.Components.Interfaces;

namespace SixthTask.Logic.UserInterface.Abstracts
{
    public abstract class View
    {
        public virtual ITicket Tikect { get; set; }
        public virtual ILuckyTicket LuckyTicket { get; set; }

        public abstract void Display(int countOfLuckyTicket);
    }
}