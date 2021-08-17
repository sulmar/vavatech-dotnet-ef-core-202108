using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.EFCore.IRepositories
{
    public interface ITimeService
    {
        DateTime GetCurrentTime();
    }

    public class MyTimeService : ITimeService
    {
        public DateTime GetCurrentTime() => DateTime.Now;
    }
}
