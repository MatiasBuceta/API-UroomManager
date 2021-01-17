using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UroomManager.Entities;

namespace UroomManager.Repository
{
    public class ReservationRepository
    {
        private string connection =
                    @"Data Source=DESKTOP-DKBV2B9\SQLEXPRESS;Initial Catalog=URmanager;Integrated Security=SSPI";

        public List<Reservation> reservationsSearch(int reservationroomids, string date) 
        {
            List<Reservation> lst = new List<Reservation>();

            using (var db = new SqlConnection(connection))
            {
                var sqlsearch = "select Id,RoomId,Assistants,ReservationDate,ReservationStartTime,ReservationEndTime from ReservationTable " +
                "where roomid=@roomid " +
                "and reservationdate=@reservationdate " +
                "order by RoomId asc";
                lst.AddRange(db.Query<Reservation>(sqlsearch, new { roomid = reservationroomids, reservationdate = date }));
            }
            return lst;
        }




    }
}
