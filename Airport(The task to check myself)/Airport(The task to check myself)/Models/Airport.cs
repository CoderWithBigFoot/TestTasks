using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport_The_task_to_check_myself_.Interfaces;
namespace Airport_The_task_to_check_myself_.Models
{
    public class Airport<T> : ICollection<T>, IEnumerable<T>, IAirport<T> where T : Airplane {

        private List<T> airplanes { set; get; } = new List<T>();
        
        public T this[int index] {
            set {
                this.airplanes[index] = value;
            }
            get {
                return this.airplanes[index];
            }
        }

        public IEnumerable<T> GetPlainsSortedByNumber() {
            return this.airplanes.OrderBy(x => x.Number);
        }

        public IEnumerable<T> GetPlainsWithMaxSeats() {
            int maxValue=0;
            try
            {
                maxValue = this.airplanes.Max(x => x.Seats);
            }
            catch (InvalidOperationException) {
                return null;
            }
            return this.airplanes.Where(x => x.Seats == maxValue);  
        }

        public double GetRangeOfFlight(RangeOfFlightType type) {

        }

    }
    




    
}
