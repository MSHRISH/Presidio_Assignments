using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDALLibrary
{
    public interface IRoomsRepository<k,T> where T : class
    {

        void GenerateRooms();
        List<Room> GetAllRooms();

        T GetRoomById(int id);

    }
}
