using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12
{
    public class Conference
    {
        public string ConferenceName { get; set; }
        public string Venue { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }

        public Conference(string conferenceName, string venue, string status, DateTime date)
        {
            ConferenceName = conferenceName;
            Venue = venue;
            Status = status;
            Date = date;
        }
    }


}
