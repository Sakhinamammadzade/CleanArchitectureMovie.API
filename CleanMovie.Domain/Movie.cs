using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Domain
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public decimal RentalCost { get; set; }
        public int RentalDuration { get; set; }

        //for many to many relation
        public IList<MovieRental> RentalRentals { get; set; }
    }
}
