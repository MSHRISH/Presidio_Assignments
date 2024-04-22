namespace ModelLibrary
{
    public class Room
    {
        private int occupancy;
        private string roomtype=string.Empty;

        public int RoomId { get; set; }
        public string RoomType
        {
            get { return roomtype; }
            set
            {
                roomtype = value;
                if (roomtype == "Single")
                {
                    occupancy = 2;
                }
                else if(roomtype == "Double")
                {
                    occupancy = 4;
                }
                else { occupancy = 8;}

            }
        }

        public int Occupancy
        {
            get { return occupancy; }
        }
        public bool OceanView { get; set; }
        
        public Room()
        {
            RoomId = 0;
            RoomType=string.Empty;
            OceanView = false;
        }
        public Room(int roomid,string _roomtype,bool oceanview)
        {
            RoomId=roomid;
            RoomType=_roomtype;
            OceanView=oceanview;
        }
    
    }
    
}
