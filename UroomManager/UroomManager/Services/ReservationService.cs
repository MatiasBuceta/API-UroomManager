using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UroomManager.Entities;
using UroomManager.Repository;

namespace UroomManager.Services
{
    public class ReservationService
    {
        public ReservationRepository reservationRepository;
        public RoomRepository roomRepository;

        public ReservationService()
        {
            reservationRepository = new ReservationRepository();
            roomRepository = new RoomRepository();
        }

        public List<Room> optimalReservations(Room room, string date, string starttime, string endtime) 
        {
            List<Room> roomlst = new List<Room>();
            List<Reservation> reservationlst = new List<Reservation>();
            List<int> reservationroomids = new List<int>();

            roomlst = roomRepository.roomsSpecSearch(room);
            
            if (roomlst.Count == 0)
            {
                roomlst = roomRepository.roomsOptSearch(room);
                if (roomlst.Count == 0)
                {
                    return roomlst;
                }
            }

            foreach (Room rooml in roomlst)
            {
                reservationlst.AddRange(reservationRepository.reservationsSearch(rooml.Id, date));
            }
            reservationlst = TimeFilter(reservationlst, starttime, endtime);
            
            List<int> roomids = new List<int>();
            List<int> reservationids = new List<int>();
            foreach (var r in roomlst)
            {
                roomids.Add(r.Id);
            }
            foreach (var re in reservationlst)
            {
                reservationids.Add(re.RoomId);
            }

            List<int> preroomlst = (roomids.Except(reservationids)).ToList();

            List<Room> finalroomlst = (from r in roomlst
                                      join re in preroomlst
                                      on r.Id equals re
                                      select r).ToList();

            foreach (var r in finalroomlst)
            {
                r.RoomName = r.RoomName.Trim();
            }

            return finalroomlst;
        }

        public List<Reservation> TimeFilter(List<Reservation> reservationlst, string starttime, string endtime) 
        {

            List<Reservation> postreservationlist = new List<Reservation>();

            var starttimeint = Int32.Parse(starttime.Replace(":", ""));
            var endtimeint = Int32.Parse(endtime.Replace(":", ""));
            var aux = 0;

            foreach (var r in reservationlst)
            {
                if ((starttimeint >= Int32.Parse(r.ReservationStartTime.Replace(":", "")) 
                    && starttimeint < Int32.Parse(r.ReservationEndTime.Replace(":", "")))
                    || (endtimeint > Int32.Parse(r.ReservationStartTime.Replace(":", "")) 
                    && endtimeint <= Int32.Parse(r.ReservationEndTime.Replace(":", ""))))
                {
                    if (aux != r.RoomId)
                    {
                        postreservationlist.Add(r);
                        aux = r.RoomId;
                    }
                    
                }
            }
            return postreservationlist;
        }
    }
}
