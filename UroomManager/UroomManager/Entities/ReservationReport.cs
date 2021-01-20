using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UroomManager.Entities
{
    public class ReservationReport
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public DateTime ReservationDate { get; set; }
        public string RoomName { get; set; }
        public int RoomOccupation { get; set; }
        public int Projector { get; set; }
        public int Blackboard { get; set; }
        public int Internet { get; set; }
    }
}
