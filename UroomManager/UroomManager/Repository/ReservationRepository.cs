﻿using Dapper;
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

        public void reservationInsert(Reservation reservation)
        {
            using (var db = new SqlConnection(connection))
            {
                var sqlinsert = "insert into ReservationTable (RoomId, Assistants, ReservationDate, ReservationStartTime, " +
                    "ReservationEndTime, Projector, Blackboard, Internet) " +
                    "values(@roomid, @assistants, @reservationdate, @reservationStartTime, " +
                    "@reservationEndTime, @projector, @blackboard, @internet)";
                var result = db.Execute(sqlinsert, new { roomid = reservation.RoomId, assistants = reservation.Assistants, reservationdate = reservation.ReservationDate, reservationStartTime = reservation.ReservationStartTime, 
                    reservationEndTime = reservation.ReservationEndTime, projector = reservation.Projector, blackboard = reservation.Blackboard, internet = reservation.Internet });
            }
        }

        public void reservationDelete(int id)
        {
            using (var db = new SqlConnection(connection))
            {
                var sqldelete = "delete from ReservationTable " +
                    "where Id = @id";
                var result = db.Execute(sqldelete, new { Id = id });
            }
        }

        public List<Reservation> reservationsSearch(int reservationroomids, string date) 
        {
            List<Reservation> lst = new List<Reservation>();

            using (var db = new SqlConnection(connection))
            {
                var sqlsearch = "select Id,RoomId,Assistants,ReservationDate,ReservationStartTime,ReservationEndTime " +
                    "from ReservationTable " +
                    "where roomid=@roomid " +
                    "and reservationdate=@reservationdate " +
                    "order by RoomId asc";
                lst.AddRange(db.Query<Reservation>(sqlsearch, new { roomid = reservationroomids, reservationdate = date }));
            }
            return lst;
        }

        public List<ReservationReport> reservationReportSearch(ReportDateEntry reportdataentry)
        {
            List<ReservationReport> lst = new List<ReservationReport>();

            using (var db = new SqlConnection(connection))
            {
                var sqlrepsearch = "select ReservationTable.RoomId, ReservationTable.ReservationDate, RoomTable.RoomName, " +
                    "count(*) as RoomOccupation, " +
                    "sum(ReservationTable.Projector) as Projector, " +
                    "sum(ReservationTable.Blackboard) as Blackboard, " +
                    "sum(ReservationTable.Internet) as Internet " +
                    "from ReservationTable " +
                    "inner join RoomTable " +
                    "on ReservationTable.RoomId=RoomTable.Id " +
                    "where ReservationDate between @startdate and @enddate " +
                    "group by RoomId, RoomName, ReservationDate " +
                    "order by RoomId asc, ReservationDate asc";
                lst.AddRange(db.Query<ReservationReport>(sqlrepsearch, new { startdate = reportdataentry.StartDate, enddate = reportdataentry.EndDate }));
            }
            return lst;
        }
    }
}
