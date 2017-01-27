using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport_The_task_to_check_myself_.Interfaces;
namespace Airport_The_task_to_check_myself_.Models
{
    public class Airport<T> : ICollection<T>, IAirport<T> where T : Airplane {

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
        public double? GetRangeOfFlight(RangeOfFlightType type) {
            try
            {
                switch (type)
                {
                    case RangeOfFlightType.min: return this.airplanes.Min(x => x.RangeOfFlight);
                    case RangeOfFlightType.max: return this.airplanes.Max(x => x.RangeOfFlight);
                    case RangeOfFlightType.average: return this.airplanes.Average(x => x.RangeOfFlight);
                    default:return null;
                }
            }
            catch (InvalidCastException) {
                return null;
            }
        }
        public IEnumerable<T> GetPlainsWithLetterInNumber(char letter) {
            try
            {
                return this.airplanes.Where(x => x.Number.ToLower().Contains(letter.ToString().ToLower()));
            }
            catch (InvalidOperationException) {
                return null; 
            }
        }


        public int Count
        {
            get
            {
                return this.airplanes.Count;
            }
        }
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
        public void Add(T item)
        {
            this.airplanes.Add(item);
        }
        public void Clear()
        {
            this.airplanes.Clear();
        }
        public bool Contains(T item)
        {
            return this.airplanes.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            this.airplanes.CopyTo(array, arrayIndex);
        }
        public bool Remove(T item)
        {
            return this.airplanes.Remove(item);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return this.airplanes.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }



    


    

    
}
