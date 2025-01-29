using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace _12
{
    public class Sessio
    {
        public string SessionTitle { get; set; }
        public string Venue { get; set; }
        public string Duration { get; set; }
        public string SessionType { get; set; }
        public DateTime Date { get; set; }
        public string SpeakerName { get; set; }
        public string SpeakerRole { get; set; }
        public int ParticipantsCapacity { get; set; }
        public string SessionStatus { get; set; }
    }
}
