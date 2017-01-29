using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport_The_task_to_check_myself_.Models;

namespace Airport_The_task_to_check_myself_.Interfaces
{
    public interface IAirport<T> where T: IAirplane{
        /* void ShowPlainsSortedByNumber();
         void ShowPlainsWithMaxSeats();
         void ShowRangeOfFlight(RangeOfFlightType type);
         void ShowPlainsWithLetterInNumber(char? letter);
         void ShowSeparatedPlanesByType();*/

        IEnumerable<T> GetPlainsSortedByNumber();
        IEnumerable<T> GetPlainsWithMaxSeats();
        double? GetRangeOfFlight(RangeOfFlightType type);
        IEnumerable<T> GetPlainsWithLetterInNumber(char? letter);
        IEnumerable<IGrouping<PlaneTypes, T>> GetSeparatedPlanesBytype();
       
    }
    
    
}
