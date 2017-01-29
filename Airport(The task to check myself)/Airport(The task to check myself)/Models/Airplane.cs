using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Airport_The_task_to_check_myself_.Interfaces;
namespace Airport_The_task_to_check_myself_.Models
{
    public class SeatsChangingArgs: EventArgs {
        public int Seats { set; get; }
    }


    /*
     The difference between planes that i selected is a Seats (their count). After
     seats setting the event SeatsChanged rises and type of plane changes. Type of plane is a field 
     of PlaneTypes type and calls TypeOfPlane. As i said it depends on Seats. 
     If seats are less than 10, TypeOfPlane is a cargo. Otherwise, it is a passenger.

        Some properties have validation attributes, that are needed to validate this properies via reflection.(as you can see, i used a Validator.TryValidateObject()) 
         */
   public class Airplane : IAirplane
    {
        protected int seats;
        protected delegate void SeatsChangedHandler(object sender, SeatsChangingArgs e);
        protected event SeatsChangedHandler SeatsChanged;

        public Airplane() {
            SeatsChanged += (sender, e) => {
                if (e.Seats<10) {
                    this.PlaneType = PlaneTypes.Cargo;
                }
                if (this.seats >= 10) {
                    this.PlaneType = PlaneTypes.Passenger;
                }
            };   
        }
        
        [Required]
        [MinLength(1,ErrorMessage ="You didn't enter the name.")]
        public string Name { set; get; }

        [Required]
        [MinLength(1, ErrorMessage = "You didn't enter the Number")]
        public string Number { set; get; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Count of seats must be from 1 to 1000")]
        public int Seats {
            set {
                this.OnSeatsChanged(new SeatsChangingArgs { Seats = value });
                this.seats = value;
                //Console.WriteLine("Here is initialization");
            }
            get { return this.seats; }
        }

        [Required]
        [Range(1,100000, ErrorMessage ="Range of flight must be from 1 to 100000")]
        public double RangeOfFlight { set; get; }

        public PlaneTypes PlaneType { protected set; get; }

        protected virtual void OnSeatsChanged(SeatsChangingArgs e) {
            if (SeatsChanged != null) {
                SeatsChanged(this, e);
            }
        }
        public override string ToString()
        {
            return $"Name: {Name},\nNumber: {Number},\nSeats: {Seats},\nRangeOfFlight: {RangeOfFlight},\nType: {PlaneType.ToString()}\n-------------------\n";
        }
    }
}
