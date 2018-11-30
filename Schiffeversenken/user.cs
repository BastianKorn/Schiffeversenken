using System;
using System.Text;

namespace Schiffeversenken
{
    public static class user
    {
        public static string AngriffStrX;
        public static int AngriffY;
        public static byte[] AngriffBytes;
        public static int AngriffX;

        public static void Attack()
        {
            Console.WriteLine("Attack!");
            Console.Write("X-Coordinate: ");
            AngriffStrX = Console.ReadLine();
            Console.Write("Y-Coordinate: ");
            AngriffY = Convert.ToInt32(Console.ReadLine());
            AngriffBytes = Encoding.ASCII.GetBytes(AngriffStrX);
            
            if (AngriffBytes[0] >= 64 && AngriffBytes[0] <= 89) {
                AngriffX = AngriffBytes[0] - 64;
            } else if (AngriffBytes[0] >= 96 && AngriffBytes[0] <= 121) {
                AngriffX = AngriffBytes[0] - 96;
            }

            if (AngriffY < 1 || AngriffY > 10) {
                service.rerenderGameField("Invalid Coordinates");
                tryAgain.tryAgainUserAttack();
            }

            if (AngriffX < 1 || AngriffX > 10) {
                service.rerenderGameField("Invalid Coordinates");
                tryAgain.tryAgainUserAttack();
            }

            switch (gameField.gameFieldBot[AngriffY,AngriffX]) {
                case "\u25E6 ":
                    Console.Clear();
                    gameField.gameFieldUserAttack[AngriffY,AngriffX] = "\u25EF ";
                    gameField.gameFieldBot[AngriffY,AngriffX] = "\u25EF ";
                    Console.WriteLine("No hit at " + AngriffStrX + (AngriffY));
                    break;
                case "\u25FC ":
                    Console.Clear();
                    gameField.gameFieldUserAttack[AngriffY,AngriffX] = "\u2718 ";
                    gameField.gameFieldBot[AngriffY,AngriffX] = "\u2718 ";
                    Console.WriteLine("Hit at " + AngriffStrX + (AngriffY));
                    break;
                case "\u25EF ":
                case "\u2718 ":
                    service.rerenderGameField("Position already Attacked");
                    tryAgain.tryAgainUserAttack();
                    break;
            }
        }
    }
}
