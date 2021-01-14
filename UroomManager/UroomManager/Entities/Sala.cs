using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UroomManager.Entities
{
    public class Sala
    {
        public int Id { get; set; }
        public int Capacidad { get; set; }
        public bool Proyector { get; set; }
        public bool Pizzara { get; set; }
        public bool Internet { get; set; }
    }
}
