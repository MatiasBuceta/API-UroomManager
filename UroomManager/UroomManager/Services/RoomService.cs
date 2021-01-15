using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UroomManager.Entities;
using UroomManager.Repository;

namespace UroomManager.Services
{
    public class RoomService
    {
        private RoomRepository roomRepository;

        public RoomService()
        {
            roomRepository = new RoomRepository();
        }

        public void roomServicePost(Room room)
        {
            roomRepository.roomInsert(room);
        }

        public void roomServiceDelete(int id)
        {
            roomRepository.roomDelete(id);
        }

        public void roomServicePut(int id, Room room)
        {
            roomRepository.roomUpdate(id, room);
        }
    }
}
