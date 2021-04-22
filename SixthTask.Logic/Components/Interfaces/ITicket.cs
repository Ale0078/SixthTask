using System.Collections.Generic;

namespace SixthTask.Logic.Components.Interfaces
{
    public interface ITicket
    {
        IEnumerator<int[]> GetEnumerator();
    }
}
