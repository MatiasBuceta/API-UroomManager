using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UroomManager.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public int Capacity { get; set; }
        public bool Projector { get; set; }
        public bool Blackboard { get; set; }
        public bool Internet { get; set; }
    }
}
