using ConnectingPlusAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Data
{
    public interface IRoomChatRepository
    {
        RoomChat GetRoom(string key);
        void CreateRoom(RoomChat room);
        void UpdateRoom(string key, RoomChat room);
    }
}
