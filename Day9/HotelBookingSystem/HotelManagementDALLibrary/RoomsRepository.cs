using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDALLibrary
{
    public class RoomsRepository : IRoomsRepository<int, Room>
    {
        readonly Dictionary<int, Room> _rooms;


        public RoomsRepository()
        {
            _rooms = new Dictionary<int, Room>();
        }
        public void GenerateRooms()
        {
            //Single Rooms
            bool oceanview=false;
            for(int i=100;i<=125;i++)
            {
                string roomtype=string.Empty;
                if (i < 110)
                {
                    roomtype = "Single";
                }
                else if(i <=120 && i > 110)
                {
                    roomtype = "Double";
                }
                else
                {
                    roomtype = "Suite";
                    oceanview=true;
                }
                Room room = new Room(i,"Single",oceanview);
                _rooms.Add(i, room);
                oceanview = !oceanview;
            }
        }

        public List<Room> GetAllRooms()
        {
            return _rooms.Values.ToList();
        }
    }
}
