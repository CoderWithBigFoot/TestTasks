using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Airport_The_task_to_check_myself_.Models
{
    public class SeatsChangingArgs: EventArgs {
        public int Seats { set; get; }
    }

   public class Airplane
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
                Console.WriteLine("Here is initialization");
            }
            get { return this.seats; }
        }

        [Required]
        [Range(1,100000, ErrorMessage ="Count of seats must be from 1 to 10000")]
        public double RangeOfFlight { set; get; }

        public PlaneTypes PlaneType { protected set; get; }



        protected virtual void OnSeatsChanged(SeatsChangingArgs e) {
            if (SeatsChanged != null) {
                SeatsChanged(this, e);
            }
        }

    }
}
