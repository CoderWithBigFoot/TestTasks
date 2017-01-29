using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport_The_task_to_check_myself_.Interfaces;
namespace Airport_The_task_to_check_myself_.Models
{
    /*Airport is implemented like a collection, via implementing ICollection<T> interface
     This collection is implemented just like a generic type where type is Airplane. 
     It means that each type that is a child of Airplane type and Airplane type too can be used insted T parameter 
         */
    public class Airport<T> : ICollection<T>, IAirport<T> where T : IAirplane {

        private List<T> airplanes { set; get; } = new List<T>();

        public T this[int index] {
            set {
                this.airplanes[index] = value;
            }
            get {
                return this.airplanes[index];
            }
        }

        private bool isEmpty() {
            if (this.Count == 0) {
                return true;
            }
            return false;
        }

        public IEnumerable<T> GetPlainsSortedByNumber() {
            return isEmpty() ?  null : this.airplanes.OrderBy(numb => numb.Number);
        }
        public IEnumerable<T> GetPlainsWithMaxSeats() {
            return isEmpty() ? null : this.airplanes.Where(pl => pl.Seats == this.airplanes.Max(x => x.Seats));
        }
        public double? GetRangeOfFlight(RangeOfFlightType type) {
            if (isEmpty()) { return null; }
            switch (type)
            {
                case RangeOfFlightType.min:return this.airplanes.Min(x => x.RangeOfFlight);
                case RangeOfFlightType.max:return this.airplanes.Max(x => x.RangeOfFlight);
                case RangeOfFlightType.average:return this.airplanes.Average(x => x.RangeOfFlight);
                default: return null;
            }
        }
        public IEnumerable<T> GetPlainsWithLetterInNumber(char? letter) {
            return (isEmpty() || letter == null) ? null : this.airplanes.Where(x => x.Number.ToLower().Contains(letter.ToString().ToLower()));
        }
        public IEnumerable<IGrouping<PlaneTypes, T>> GetSeparatedPlanesBytype() {
            return (isEmpty()) ? null : this.airplanes.GroupBy(gr=>gr.PlaneType);
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

        public override string ToString()
        {
            string result = null;
            if (this.Count == 0) { return "There are no planes in airport."; }
           
            else {
                result += "\n      All planes is airport\n";
                foreach (var currentPlane in this.airplanes) {
                    result += currentPlane.ToString();
                    result += "\n";
                }
            }
            return result;
        }
    }



    


    

    
}
