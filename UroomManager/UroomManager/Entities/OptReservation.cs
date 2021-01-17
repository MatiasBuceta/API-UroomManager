using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UroomManager.Entities
{
    public class OptReservation
    {
        public int Capacity { get; set; }
        public int Projector { get; set; }
        public int Blackboard { get; set; }
        public int Internet { get; set; }
        public string ReservationDate { get; set; }
        public string ReservationStartTime { get; set; }
        public string ReservationEndTime { get; set; }
    }
}
