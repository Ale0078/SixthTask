using System;

using SixthTask.Logic.Components.Interfaces;
using SixthTask.Logic.Components.Builders.Interfaces;
 
namespace SixthTask.Logic.Components.Builders
{
    public class LuckyTicketBuilder : ILuckyTicketBuilder
    {
        public string LuckyTicketType { get; init; }

        public LuckyTicketBuilder(string luckyTicketType) 
        {
            LuckyTicketType = luckyTicketType;
        }

        public ILuckyTicket Create() => LuckyTicketType switch
        {
            "Moskow" => new MoskowLuckyTicket(),
            "Piter" => new PiterLuckyTicket(),
            _ => throw new ArgumentException("Type of lucky tiket must be Moskow or Piter")
        };
    }
}
