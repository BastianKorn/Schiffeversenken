using System;
using System.Text;

namespace Schiffeversenken
{
    public static class bot
    {
        public static int randomX = 0;
        public static int randomY = 0;
        public static int kiX = 0;
        public static int kiY = 0;
        public static int Ost = 1;
        public static int Süd = 0;
        public static int West = 0;
        public static int Nord = 0;
        public static int no = 0;
        public static int yes = 1;
        public static void Attack()
        {
            if (gameField.gameFieldUser[kiY, kiX] == "\u2718 ")
            {
                kiX = kiX - West + Ost;
                kiY = kiY + Süd - Nord;
                switch (gameField.gameFieldUser[kiY,kiX]) {
                    case "\u25E6 ": // Feld
                        gameField.gameFieldUser[kiY,kiX] = "\u25EF ";
                        if (Ost == yes) {
                            Süd = yes;
                            Ost = no;
                            kiX = randomX;
                            kiY = randomY;
                        } else if (Süd == yes) {
                            West = yes;
                            Süd = no;
                            kiX = randomX;
                            kiY = randomY;
                        } else if (West == yes) {
                            Nord = yes;
                            West = no;
                            kiX = randomX;
                            kiY = randomY;
                        } else if (Nord == yes) {
                            Nord = no;
                            Ost = yes;
                        }
                        break;
                    case "\u25EF ": // Wasser
                    case ". ": // Spielfeldgrenze
                    case "\u2718 ": // Kaputtes Schiff
                        if (Ost == yes) {
                            Süd = yes;
                            Ost = no;
                            West = no;
                            Nord = no;
                            kiX = randomX;
                            kiY = randomY;
                        } else if (Süd == yes) {
                            West = yes;
                            Süd = no;
                            Nord = no;
                            Ost = no;
                            kiX = randomX;
                            kiY = randomY;
                        } else if (West == yes) {
                            Nord = yes;
                            West = no;
                            Süd = no;
                            Ost = no;
                            kiX = randomX;
                            kiY = randomY;
                        } else if (Nord == yes) {
                            Nord = no;
                            West = no;
                            Süd = no;
                            Ost = yes;
                        }
                        tryAgain.tryAgainBotAttack();
                        break;
                    case "\u25FC ": // Schiff
                        gameField.gameFieldUser[kiY,kiX] = "\u2718 "; // Kaputtes Schiff
                        break;
                }
            } else {

                Random rnd = new Random();
                randomX = rnd.Next(1, 11);
                randomY = rnd.Next(1, 11);
                kiX = randomX;
                kiY = randomY;

                switch (gameField.gameFieldUser[randomY,randomX]) {
                    case "\u25E6 ": // Feld
                        gameField.gameFieldUser[randomY,randomX] = "\u25EF ";
                        break;
                    case "\u25FC ": // Schiff
                        gameField.gameFieldUser[randomY,randomX] = "\u2718 "; // Kaputtes Schiff
                        break;
                    case "\u25EF ": // Wasser
                    case "\u2718 ": // Kaputtes Schiff
                        tryAgain.tryAgainBotAttack();
                        break;
                }
            }
        }
    }
}
