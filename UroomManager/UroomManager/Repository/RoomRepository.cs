using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UroomManager.Entities;

namespace UroomManager.Repository
{
    public class RoomRepository
    {
        private string connection =
                    @"Data Source=DESKTOP-DKBV2B9\SQLEXPRESS;Initial Catalog=URmanager;Integrated Security=SSPI";

        public void roomInsert(Room room)
        {

            using (var db = new SqlConnection(connection))
            {
                var sqlinsert = "insert into RoomTable(RoomName,Capacity,Projector,Blackboard,Internet) Values(@roomname, @capacity, @projector, @blackboard, @internet)";
                var result = db.Execute(sqlinsert, new { roomname = room.RoomName,capacity = room.Capacity,projector = room.Projector,blackboard = room.Blackboard,internet = room.Internet });
            }
        }

        public void roomDelete(int id)
        {
            using (var db = new SqlConnection(connection))
            {
                var sqldelete = "delete from RoomTable where Id = @id";
                var result = db.Execute(sqldelete, new { Id = id });
            }
        }
        public void roomUpdate(int id, Room room)
        {
            room.Id = id;
            using (var db = new SqlConnection(connection))
            {
                var sqledit = "update RoomTable set roomname=@roomname, capacity=@capacity, projector=@projector, blackboard=@blackboard, internet=@internet where Id=@id";
                var result = db.Execute(sqledit, new { id = room.Id, roomname = room.RoomName, capacity = room.Capacity, projector = room.Projector, blackboard = room.Blackboard, internet = room.Internet });
            }
        }
    }
}
