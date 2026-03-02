using System.Security.Cryptography;

class Program
{
    static int RandomNumber(int distance, int roomTypes)
    {
        Random rnd = new Random();
        int roomType = 0;
        int deadEndChance = -10;
        int maxDistance = 10;
        for (int i = 0; i <= distance; i++)
        {
            deadEndChance = deadEndChance + 5;
        }
        roomType = rnd.Next(1, roomTypes);
        int deadEnd = rnd.Next(1,100);
        Console.WriteLine($"Dead End Number: {deadEnd}");
        Console.WriteLine($"Dead End Chance: {deadEndChance}");
        if (deadEnd < deadEndChance && deadEndChance > 0 || distance >= maxDistance)
        {
            roomType = 0;
            Console.WriteLine("DeadEnd");
        }
        return(roomType);

    }
    static void Main(string[] args)
    {
        int roomTypes = 11; //+1 (11 = 10)
        int roomType = roomTypes + 1;
        int distance = 0;
        int lastRoom = roomType;
        Console.WriteLine("Starter Room");
        while (roomType != 0)
        {
            while (roomType == lastRoom)
            {
                roomType = RandomNumber(distance, roomTypes);
            }

            if (distance == 10)
            {
                roomType = 0;
            }
            if (roomType == 0)
            {
                Console.WriteLine("Final Room");
                break;
            }
            distance++;

            Console.WriteLine($"Room Type: {roomType} Distance: {distance}");
            lastRoom = roomType;
        }
        
    }
}