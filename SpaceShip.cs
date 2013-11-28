using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SHIP
{
    /// <summary>
    /// James Cooper
    /// 1337466
    /// Feedback
    /// </summary>
    class SpaceShip
    {
        int shipWeight = 1000;
        public int currentFuel = 500;
        int fuelUsedinBurn;
        int thrust;
        int currentWeight;
        string input;
        public float verticalSpeed = 0f;
        float accelaration = 0f;
        float gravity = -9.8f;
        public float altitude = 500f;

        public static void RenderFuelMessage(string message)
        {
            Console.CursorLeft = 0;
            int maxCharacterWidth = Console.WindowWidth - 1;
            if (message.Length > maxCharacterWidth)
            {
                message = message.Substring(0, maxCharacterWidth - 3) + "...";
            }
            message = message + new string(' ', maxCharacterWidth - message.Length);
            Console.Write(message);
        }
        public void RenderFuel(int percentage, char progressBarCharacter, ConsoleColor color, string message)
        {
            Console.CursorVisible = false;
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.CursorLeft = 0;
            int width = Console.WindowWidth - 1;
            int newWidth = (int)((width * percentage) / 100d);
            string progBar = new string(progressBarCharacter, newWidth) +
                  new string(' ', width - newWidth);
            Console.Write(progBar);
            if (string.IsNullOrEmpty(message)) message = "";
            Console.Write(Environment.NewLine);
            RenderFuelMessage(message);
            Console.CursorTop--;
            Console.Write(Environment.NewLine);
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = originalColor;
            Console.CursorVisible = true;
        }
        public void RenderScreen(int fuel)
        {
            Console.Clear();
            Console.WriteLine("Welcome To the Ship");
            Console.Write(Environment.NewLine);
            if ((fuel / 5) > 50)
            {
                RenderFuel((fuel / 5), '\u2590', ConsoleColor.Green, (fuel + "KG Fuel Remaining"));
            }
            else if ((fuel / 5) > 25)
            {
                RenderFuel((fuel / 5), '\u2590', ConsoleColor.Yellow, (fuel + "KG Fuel Remaining"));
            }
            else
            {
                RenderFuel((fuel / 5), '\u2590', ConsoleColor.Red, (fuel + "KG Fuel Remaining"));
            }
            Console.Write(Environment.NewLine);
            Console.Write("Total Ship Weight: " + (shipWeight + currentFuel) + "KG");
            Console.Write(" | Vertical Speed: " + verticalSpeed + " m/s");
            Console.Write(" | Altitude: " + altitude + " m");
            Console.Write(Environment.NewLine);
            Console.Write(Environment.NewLine);
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1: Apply thrust");
            Console.WriteLine("2: Wait");
            Console.Write(Environment.NewLine);
            Console.Write(Environment.NewLine);
            Console.Write("Please select an option: ");
            input = Console.ReadLine();
        }
        public void Thrust()
        {
            currentWeight = shipWeight + currentFuel;
            if (currentFuel > 0)
            {
                Console.WriteLine("How much fuel do you want to use?");
                fuelUsedinBurn = int.Parse(Console.ReadLine());
                thrust = fuelUsedinBurn * 2000;
                accelaration = (thrust / currentWeight) + gravity;
                currentFuel = currentFuel - fuelUsedinBurn;
            }
            else
            {
                Console.WriteLine("NO FUEL!");
            }

        }
        public void ApplyGravity()
        {
            currentWeight = shipWeight + currentFuel;
            accelaration = gravity;
        }
        public void CheckAltitude()
        {
            verticalSpeed = verticalSpeed + accelaration;
            altitude = altitude + verticalSpeed;
            RenderScreen(currentFuel);
        }
        public void movement()
        {
        Start:

            if (input != null)
            {
                int caseSwitch = int.Parse(input);
                switch (caseSwitch)
                {
                    case 1:
                        Thrust();
                        Console.WriteLine("Thrust Applied");
                        CheckAltitude();

                        break;
                    case 2:
                        ApplyGravity();
                        Console.WriteLine("Waiting");
                        CheckAltitude();
                        break;
                    default:
                        Console.WriteLine("Bad Input... Gravity Applied only!");
                        goto case 2;
                }
            }
            else
            {
                Console.WriteLine("No Input Detected");
                goto Start;
            }

        }
    }
}
