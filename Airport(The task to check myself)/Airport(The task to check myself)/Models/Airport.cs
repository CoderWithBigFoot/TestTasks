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

        private bool isEmpty() {
            if (this.Count == 0) {
                Console.WriteLine("There are no planes.");
                return true;
            }
            return false;
        }

        public void ShowPlainsSortedByNumber() {
            if (isEmpty()) { return; }

            Console.WriteLine("   Planes that sorted by Number\n");
            foreach (var plane in this.airplanes.OrderBy(x => x.Number)) {
                Console.WriteLine(plane.ToString());
            }
            Console.WriteLine("\n-----------------------\n");
        }
        public void ShowPlainsWithMaxSeats() {
            if (isEmpty()) { return; }
            int max = this.airplanes.Max(pl => pl.Seats);

            Console.WriteLine("    Planes with max seats");
            foreach (var current in this.airplanes.Where(x => x.Seats == max)) {
                Console.WriteLine(current.ToString());
            }
            Console.WriteLine("\n-----------------------\n");
        }

        public void ShowRangeOfFlight(RangeOfFlightType type) {
            if (isEmpty()) { return; }
            
                switch (type)
                {
                case RangeOfFlightType.min: Console.WriteLine("The min range of flight: "+this.airplanes.Min(x => x.RangeOfFlight));return;
                case RangeOfFlightType.max: Console.WriteLine("the max range of flight: "+this.airplanes.Max(x => x.RangeOfFlight));return;
                case RangeOfFlightType.average: Console.WriteLine("The average range of flight: " + this.airplanes.Average(x => x.RangeOfFlight)); return;
                default: Console.WriteLine("Unknown type");return;
                }
        }
        public void ShowPlainsWithLetterInNumber(char? letter) {
            if (isEmpty() || letter == null) { return; }

            Console.WriteLine("    There are planes with ("+letter+") letter in number\n");
            var result = this.airplanes.Where(x => x.Number.ToLower().Contains(letter.ToString().ToLower()));
            if (result.Count() == 0) { Console.WriteLine("There are no such planes."); return; }

            foreach (var current in result) {
                Console.WriteLine(current.ToString());
            }
            Console.WriteLine("\n-----------------------\n");

        }

        public void ShowSeparatedPlanesByType() {

            if (isEmpty()) { return; }

            Console.WriteLine("    Planes that separated by type: \n");
            foreach (var currentGroup in airplanes.GroupBy(x => x.PlaneType)) {
                Console.WriteLine($" Type: {currentGroup.Key.ToString()}\n");
                foreach (var element in currentGroup) {
                    Console.WriteLine(element.ToString());
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("\n-----------------------\n");
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
