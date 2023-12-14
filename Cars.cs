using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Bilar
{
    class Cars
    {
        public string Name { get; set; }
        public int Distance { get; set; }
        public int Speed { get; protected set; }

        public Cars(string name, int speed)
        {
            Name = name;
            Speed = speed;
            Distance = 0;
        }
      
    public virtual void Race()
        {
            Console.WriteLine($"{Name} starts the race!");
            Console.WriteLine("=======================");
            while (Distance < 10)
            {
                Move();
                CheckForEvent();
                Thread.Sleep(1000);

               
                if (Distance % 3 == 0) 
                {
                    Console.WriteLine($"Checking for events for {Name}...");
                    CheckForEvent();
                    
                }
            }

            Console.WriteLine($"{Name} finished the race!");
        }

        public void Move()
        {
            Distance += Speed;
            Console.WriteLine($"{Name} is at {Distance} km.");
        }

        public void CheckForEvent()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 51);

            if (randomNumber == 1)
            {
                Console.WriteLine($"{Name} has run out of gas. Needs to refuel and stops for 30 seconds.");
                Thread.Sleep(30000); 
            }
            else if (randomNumber <= 3) 
            {
                Console.WriteLine($"{Name} has a flat tire. Needs to change the tire and stops for 20 seconds.");
                Thread.Sleep(20000);
            }
            else if (randomNumber <= 8) 
            {
                Console.WriteLine($"{Name} has a bird on the windshield. Needs to clean it and stops for 10 seconds.");
                Thread.Sleep(10000);
            }
            else if (randomNumber <= 18)
            {
                Console.WriteLine($"{Name}'s engine has a problem. Speed reduced by 1 km/h.");
                Speed = Math.Max(Speed - 1, 0); 
            }
        }

    }
}