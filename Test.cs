using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class Test
    {
        
        public Test()
        {

        }
        public void TestCase(bool testing)
        {
            Debug.Assert(testing, "Test failed");
        }
        /// <summary>
        /// Test to check if the player can move to an adjacent room
        /// </summary>
        /// <param name="room">Current Room</param>
        /// <param name="map">Current Map</param>
        public void checkAdjacentRooms(Room room, Map map)
        {
            int x = room.GetRoomX();
            int y = room.GetRoomY();
            bool roomFound = false;
            bool roomOnXEdge = false;
            bool roomOnYEdge = false;
            bool roomOnWidthEdge = false;
            bool roomOnHeightEdge = false;
            if (x == 0)
            {
                roomOnXEdge = true;
            }
            if (y == 0)
            {
                roomOnYEdge = true;
            }
            if (x == map.width - 1)
            {
                roomOnWidthEdge = true;
            }
            if (y == map.height - 1)
            {
                roomOnHeightEdge = true;
            }
            if (roomOnXEdge == false)
            {
                if (map.layout[x - 1, y] == 1)
                {
                    roomFound = true;
                }
            }
            if (roomOnYEdge == false)
            {
                if (map.layout[x, y - 1] == 1)
                {
                    roomFound = true;
                }
            }
            if (roomOnWidthEdge == false)
            {
                if (map.layout[x + 1, y] == 1)
                {
                    roomFound = true;
                }
            }
            if (roomOnHeightEdge == false)
            {
                if (map.layout[x, y + 1] == 1)
                {
                    roomFound = true;
                }
            }
            Debug.Assert(roomFound, "No adjacent rooms found");
        }
        /// <summary>
        /// Test to check if the monster is dead
        /// </summary>
        /// <param name="monsterHealth">Monster HP</param>
        public void checkMonsterDead(int monsterHealth)
        {
            Debug.Assert(monsterHealth >= 0, "Monster health fell below 0");
        }

        /// <summary>
        /// Test to check if the player is dead
        /// </summary>
        /// <param name="player">Player Object</param>
        public void checkPlayerDead(Player player)
        {
            Debug.Assert(player.health >= 0, "Player health fell below 0");
        }

    }
}
