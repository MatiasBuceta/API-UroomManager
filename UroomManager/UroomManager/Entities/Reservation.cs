using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UroomManager.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public TimeSpan ReservationTime { get; set; }
    }
}
