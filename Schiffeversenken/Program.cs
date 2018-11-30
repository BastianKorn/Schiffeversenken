using System;
using System.Text;

namespace Schiffeversenken
{
    class Program
    {
        static int Main(string[] args)
        {
            gameField.makeGameField();
            Console.Clear();

            for (int shipLength = 5; shipLength > 1; shipLength--) {
                try {
                    service.setShipPhase(shipLength);
                } catch (FormatException) {
                    Console.Clear();
                    Console.WriteLine("Invalid Position");
                    shipLength++;
                    continue;
                } catch (IndexOutOfRangeException) {
                    Console.Clear();
                    Console.WriteLine("Invalid Position");
                    shipLength++;
                    continue;
                }
            }

            Console.WriteLine("Schiffe Versenken by Bastian Korn");
            
            while(gameField.foundUserShip == true && gameField.foundBotShip == true) {
                try {
                    service.attackPhase();
                    if (gameField.foundBotShip == false) {
                        service.win();
                        return 3;
                    } else if (gameField.foundUserShip == false) {
                        service.lose();
                        return 4;
                    }
                } catch (FormatException) {
                    Console.Clear();
                    Console.WriteLine("Invalid Input Format");
                    continue;
                } catch (IndexOutOfRangeException) {
                    Console.Clear();
                    Console.WriteLine("Invalid Position");
                    continue;
                }
            }
            return 0;
        }
    }
}
