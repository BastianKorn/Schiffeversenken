using System;
using System.Text;

namespace Schiffeversenken
{
    public static class gameField
    {
        public static string gameFieldXAxis = "   A B C D E F G H I J ";
        public static string[,] gameFieldBot = new string[12,12];
        public static string[,] gameFieldUser = new string[12,12];
        public static string[,] gameFieldUserAttack = new string[12,12];

        public static bool foundUserShip = true;
        public static bool foundBotShip = true;

        public static void makeGameField()
        {
            for (int i = 0; i < 12; i++) {
                for (int k = 0; k < 12; k++) {
                    if ( i == 0 || i == 11 || k == 0 || k == 11)
                    {
                        gameFieldUserAttack[i,k] = ". ";
                        gameFieldUser[i,k] = ". ";
                        gameFieldBot[i,k] = ". ";
                    } else {
                    gameFieldUserAttack[i,k] = "\u25E6 ";
                    gameFieldUser[i,k] = "\u25E6 ";
                    gameFieldBot[i,k] = "\u25E6 ";
                    }
                }
            }
        }

        public static void renderGameField()
        {
            service.blueBlack();
            Console.Write(gameFieldXAxis);
            service.blackWhite();
            Console.Write("   |   ");
            service.blueBlack();
            Console.WriteLine(gameFieldXAxis);
            for (int i = 1; i < gameFieldUserAttack.GetLength(0)-1; i++) {
                if(i == 10) {
                    Console.Write((i) + " ");
                } else {
                    Console.Write((i) + "  ");
                }
                for (int k = 1; k < gameFieldUserAttack.GetLength(1)-1; k++) {
                    Console.Write(gameFieldUserAttack[i,k]);
                }
                service.blackWhite();
                Console.Write("   |   ");
                service.blueBlack();
                if(i == 10) {
                    Console.Write((i) + " ");
                } else {
                    Console.Write((i) + "  ");
                }
                for (int k = 1; k < gameFieldUser.GetLength(1)-1; k++) {
                    Console.Write(gameFieldUser[i,k]);
                }
                Console.WriteLine();
            }
            service.blackWhite();
        }

        public static void checkGameFieldBot()
        {
            foundBotShip = false;
            for (int i = 1; i < gameFieldBot.GetLength(0)-1; i++) {
                for (int k = 1; k < gameFieldBot.GetLength(1)-1; k++) {
                    if(gameFieldBot[i,k] == "\u25FC ") {
                        foundBotShip = true;
                    }
                }
            }
        }

        public static void checkGameFieldUser()
        {
            foundUserShip = false;
            for (int i = 1; i < gameFieldUser.GetLength(0)-1; i++) {
                for (int k = 1; k < gameFieldUser.GetLength(1)-1; k++) {
                    if(gameFieldUser[i,k] == "\u25FC ") {
                        foundUserShip = true;
                    }
                }
            }
        }
    }
}
