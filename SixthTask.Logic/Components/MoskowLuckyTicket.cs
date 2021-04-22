using SixthTask.Logic.Components.Interfaces;

namespace SixthTask.Logic.Components
{
    internal class MoskowLuckyTicket : ILuckyTicket
    {
        public bool IsLuckyTicket(params int[] ticket)
        {
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < ticket.Length; i++)
            {
                if ((ticket.Length / 2.0) > i)
                {
                    leftSum += ticket[i];
                }
                else 
                {
                    rightSum += ticket[i];
                }
            }

            return leftSum == rightSum;
        }
    }
}
