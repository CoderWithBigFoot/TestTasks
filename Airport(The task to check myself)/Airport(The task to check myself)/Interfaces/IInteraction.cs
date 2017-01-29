using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport_The_task_to_check_myself_.Models;
using System.ComponentModel.DataAnnotations;
namespace Airport_The_task_to_check_myself_.Interfaces
{
   public interface IInteraction
    {
        IAirplane GetAirplaneFromUser();
        char? GetLetterFromUser();
        void ShowPlanes(IEnumerable<IAirplane> collection);
        void ShowPlanes(IEnumerable<IGrouping<PlaneTypes, IAirplane>> collection);
        void ShowRangesOfFlight(double? minRangeOfFlight, double? maxRangeOfFlight,double? averageRangeOfFlight);
    }
}
