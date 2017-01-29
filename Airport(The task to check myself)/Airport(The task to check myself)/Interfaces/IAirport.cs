using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport_The_task_to_check_myself_.Models;

namespace Airport_The_task_to_check_myself_.Interfaces
{
    public interface IAirport<T> where T: Airplane{
        /* void ShowPlainsSortedByNumber();
         void ShowPlainsWithMaxSeats();
         void ShowRangeOfFlight(RangeOfFlightType type);
         void ShowPlainsWithLetterInNumber(char? letter);
         void ShowSeparatedPlanesByType();*/

        IEnumerable<Airplane> GetPlainsSortedByNumber();
        IEnumerable<Airplane> GetPlainsWithMaxSeats();
        double? GetRangeOfFlight(RangeOfFlightType type);
        IEnumerable<Airplane> GetPlainsWithLetterInNumber(char? letter);
        IEnumerable<IGrouping<PlaneTypes, Airplane>> GetSeparatedPlanesBytype();
       
    }
    
    
}
