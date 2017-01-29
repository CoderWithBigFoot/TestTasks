using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_The_task_to_check_myself_.Interfaces
{
   public interface IAirplane
    {
        string Name { set; get; }
        string Number { set; get; }
        int Seats { set; get; }
        double RangeOfFlight { set; get; }
        PlaneTypes PlaneType { get; }
    }
}
