using System;

namespace DungeonExplorer
{
    public class Map
    {
        public int[,] layout;
        public int width;
        public int height;
        public Room[,] roomLayoutArray;
        /// <summary>
        /// Map Constructor
        /// </summary>
        /// <param name="width">the width of the map</param>
        /// <param name="height">the height of the map</param>
        /// <param name="startingRoom">the room the player starts in</param>
        public Map(int width, int height, Room startingRoom)
        {
            // Create a new map
            this.width = width;
            this.height = height;
            Random rnd = new Random();
            layout = new int[width, height];
            roomLayoutArray = new Room[width, height];
            for (int j = 0; j < width; j++)
            {
                for (int i = 0; i < height; i++)
                {
                    // Player always starts at top left of the map
                    // So top left is always 1
                    // 1 means there is a room and 0 means there isn't a room
                    if (i == 0 && j == 0)
                    {
                        //Starting Room
                        layout[i, j] = 1;
                        roomLayoutArray[i, j] = startingRoom;
                    }
                    else if(i == 1 && j == 0)
                    {
                        // Room to the right of the starting room
                        layout[i, j] = 1;
                        roomLayoutArray[i, j] = new Room(i, j);
                    }
                    else if (i == 0 && j == 1)
                    {
                        // Room below the starting room
                        layout[i, j] = 1;
                        roomLayoutArray[i, j] = new Room(i, j);
                    }
                    else
                    {
                        // Randomly generate rooms
                        layout[i, j] = rnd.Next(0, 2);
                        // If there is a room, create a new room object
                        if (layout[i, j] == 1) roomLayoutArray[i, j] = new Room(i, j);
                    }
                }
            }
            Test test = new Test();
            test.checkAdjacentRooms(startingRoom, this);

        }

        /// <summary>
        /// Change the room
        /// </summary>
        /// <param name="currentRoom">the room the player is currently in</param>
        /// <returns>the room the player wants to move to</returns>
        public Room changeRoom(Room currentRoom)
        {
            string direction = "";
            int currentX = currentRoom.GetRoomX();
            int currentY = currentRoom.GetRoomY();
            bool roomMenu = true;
            while (roomMenu)
            {
                // Display the change room menu
                Console.WriteLine("Change Room Menu: ");
                Console.WriteLine("Commands:");
                Console.WriteLine("1) Right");
                Console.WriteLine("2) Left");
                Console.WriteLine("3) Up");
                Console.WriteLine("4) Down");
                Console.WriteLine("5) Exit");
                Console.WriteLine("Choose a command (right, left, up, down, exit): ");
                Console.Write("> ");
                direction = Console.ReadLine().ToLower();
                if (direction == "right")
                {
                    // Check if the room to the right exists
                    if (currentX + 1 <= width && layout[currentX +1,currentY] == 1)
                    {
                        // Return the room to the right
                        return roomLayoutArray[currentX + 1, currentY];
                    }
                }
                else if (direction == "left")
                {
                    // Check if the room to the left exists
                    if (currentX - 1 >= 0 && layout[currentX -1, currentY] == 1)
                    {
                        // Return the room to the left
                        return roomLayoutArray[currentX - 1, currentY];
                    }
                }
                else if (direction == "up")
                {
                    // Check if the room "above" exists
                    if (currentY - 1 >= 0 && layout[currentX, currentY -1] == 1)
                    {
                        // Return the room "above"
                        return roomLayoutArray[currentX, currentY - 1];
                    }
                }
                else if (direction == "down")
                {
                    // Check if the room "below" exists
                    if (currentY + 1 <= height && layout[currentX, currentY + 1] == 1)
                    {
                        // Return the room "below"
                        return roomLayoutArray[currentX, currentY + 1];
                    }
                }
                else if (direction == "exit")
                {
                    // Exit the room menu
                    roomMenu = false;
                }
                else
                {
                    // If a command is not recognised
                    Console.WriteLine("Invalid direction");
                }
                // If there is no door in the direction the player wants to go
                Console.WriteLine("There is no door to enter in that direction!");
                
            }
            // Return the currentRoom if the player exits the room menu
            return currentRoom;
        }
        

        /// <summary>
        /// Display the current map
        /// </summary>
        public void DisplayMap(Room currentRoom)
        {
            Console.WriteLine("After reading your map you see:");
            // Get the current room coordinates
            int currentX = currentRoom.GetRoomX();
            int currentY = currentRoom.GetRoomY();
            Console.WriteLine($"Current Coordinates: ({currentX},{currentY})");
            // Display the Legend
            Console.WriteLine("Legend:");
            Console.WriteLine("O = Room");
            Console.WriteLine("X = No Room");
            Console.WriteLine("P = Player");
            // Display the Map
            for (int j = 0; j < width; j++)
            {
                for (int i = 0; i < height; i++)
                {

                    Console.Write("|");
                    // Displays a O if there is a room and a X if there isn't
                    if (layout[i, j] == 1)
                    {
                        if (i == currentX && j == currentY)
                        {
                            Console.Write("P");
                        }
                        else
                        {
                            Console.Write("O");
                        }
                    }
                    else
                    {
                        Console.Write("X");
                    }
                    Console.Write($"({i},{j})|");
                }
                Console.WriteLine();
            }
        }


    }
}