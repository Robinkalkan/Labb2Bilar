using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Linq;


namespace Labb2Bilar;
class Program
{
    static void Main()
    {
        List<Cars> cars = new List<Cars>
        {
            new Cars("TheDestroyer", 120),
            new Cars("TheBolt", 120),
            new Cars("WingedBeast", 120),
            new Cars("SpeedOfLight", 120),
        };

        List<Thread> threads = new List<Thread>();

      
        foreach (var car in cars)
        {
            Thread thread = new Thread(() => RaceWithEvents(car));
            threads.Add(thread);
            thread.Start();
         

        }

        
        foreach (var thread in threads)
        {
            thread.Join();
            
        }
        
        Console.WriteLine("\t ~~~~~~~~~~ Race finished! ~~~~~~~~~~~~");
       

        
        Console.WriteLine("Press Enter to get the race status:");
        Console.ReadLine();
        PrintRaceStatus(cars);
    }

    static void RaceWithEvents(Cars car)
    {
        Console.WriteLine($"{car.Name} starts the race!");

        while (car.Distance < 10)
        {
            car.Move();
            car.CheckForEvent();
            Thread.Sleep(1000); 
            if (car.Distance % 3 == 0) 
            {
                Console.WriteLine($"Checking for events for {car.Name}...");
                car.CheckForEvent();
            }
        }

        Console.WriteLine($"{car.Name} finished the race!");
    }

    static void PrintRaceStatus(List<Cars> cars)
    {
        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Name} - Distance: {car.Distance} km - Speed: {car.Speed} km/h");
        }
    }
}