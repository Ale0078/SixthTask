using System;

using SixthTask.Logic.UserInterface.Abstracts;

namespace SixthTask.Views
{
    public class LuckyTicketView : View
    {
        public override void Display(int countOfLuckyTicket)
        {
            Console.WriteLine($"Amount of lucky ticket: {countOfLuckyTicket}");
        }
    }
}
