using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHIP
{
    class Program
    {
        static void Main(string[] args)
        {
            SpaceShip ship = new SpaceShip();
            ship.RenderScreen(ship.currentFuel);
            while (ship.altitude > 0)
            {
                if (ship.verticalSpeed > -5 && (ship.altitude + ship.verticalSpeed <= 0))
                {
                    Console.WriteLine("Ship Successfully Landed!");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else if (ship.verticalSpeed < -5 && (ship.altitude + ship.verticalSpeed <= 0))
                {
                    Console.WriteLine("Ship Crashed!!!");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else
                {
                    ship.movement();
             
                }
                
            }
           
        }
    }
}
