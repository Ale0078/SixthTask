using System;
using System.Collections.Generic;

using SixthTask.Logic.Components.Interfaces;

namespace SixthTask.Logic.Components
{
    internal class Ticket : ITicket
    {
        public int Size { get; init; }
        public int MinValue { get; init; }
        public int MaxValue { get; init; }

        public Ticket(int minValue, int maxValue, int size) 
        {
            Size = size;
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public IEnumerator<int[]> GetEnumerator() 
        {
            int[] ticket = new int[Size];
            int counterFromEnd = 1;

            for (int i = MinValue; i < MaxValue; i++)
            {
                foreach (var number in i.ToString())
                {
                    ticket[^counterFromEnd] = Convert.ToInt32(number.ToString());

                    counterFromEnd++;
                }

                yield return ticket;

                counterFromEnd = 1;
            }
        }
    }
}
