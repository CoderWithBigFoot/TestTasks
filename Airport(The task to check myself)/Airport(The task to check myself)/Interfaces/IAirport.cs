using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport_The_task_to_check_myself_.Models;

namespace Airport_The_task_to_check_myself_.Interfaces
{
    public interface IAirport<T> where T: Airplane{

        void GetPlainsSortedByNumber();
        void GetPlainsWithMaxSeats();
        void GetRangeOfFlight(RangeOfFlightType type);
        void GetPlainsWithLetterInNumber(char? letter);
        void SeparateByType();

    }
    
    
}
