using System;

namespace Schiffeversenken
{
    public static class service
    {
        public static void rerenderGameField(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            gameField.renderGameField();
        }

        public static void setShipPhase(int shipLength)
        {
            Console.WriteLine("Schiffe Versenken by Bastian Korn");
            gameField.renderGameField();
            ship.getUserShip(shipLength);
            ship.checkUserShipPosition();
            ship.checkIfUserShip();
            ship.setUserShip(shipLength);
            ship.getBotShip(shipLength);
            ship.checkBotShipPosition();
            ship.checkIfBotShip();
            ship.setBotShip(shipLength);
        }

        public static void attackPhase()
        {
            gameField.renderGameField();

            user.Attack();
            gameField.checkGameFieldBot();

            bot.Attack();
            gameField.checkGameFieldUser();
        }

        public static void win()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("You Won!");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void lose()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("You Lost!");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

        }

        public static void blackWhite()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void blueBlack()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
