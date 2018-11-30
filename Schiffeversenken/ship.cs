using System;
using System.Text;

namespace Schiffeversenken
{
    public static class ship
    {
        public static string userShipStrX;
        public static int userShipY;
        public static string userShipRichtung;
        public static byte[] userShipBytes;
        public static int userShipX;
        public static int userShipLength;
        public static int botShipX;
        public static int botShipY;
        public static int botShipRichtung;
        public static int botShipLength;

        public static void getUserShip(int userShipLen)
        {
            userShipLength = userShipLen;
            Console.WriteLine("Beginning of the ship (" + userShipLength + " long)");
            Console.Write("X-Coordinate: ");
            userShipStrX = Console.ReadLine();
            Console.Write("Y-Coordinate: ");
            userShipY = Convert.ToInt32(Console.ReadLine());
            userShipBytes = Encoding.ASCII.GetBytes(userShipStrX);
            if (userShipBytes[0] >= 64 && userShipBytes[0] <= 90) {
                userShipX = userShipBytes[0] - 64;
            } else if (userShipBytes[0] >= 96 && userShipBytes[0] <= 122) {
                userShipX = userShipBytes[0] - 96;
            } else {
                userShipX = 0;
            }
            Console.Write("Direction (N S W O): ");
            userShipRichtung = Console.ReadLine();
        }

        public static void checkUserShipPosition()
        {
            if (userShipY < 1 || userShipY > 10 || userShipX < 1 || userShipX > 10) {
                service.rerenderGameField("Invalid Coordinate");
                tryAgain.tryAgainCheckUserShipPosition();
            }

            if (userShipRichtung != "N" && userShipRichtung != "S" && userShipRichtung != "W" && userShipRichtung != "O" && userShipRichtung != "n" && userShipRichtung != "s" && userShipRichtung != "w" && userShipRichtung != "o") {
                service.rerenderGameField("Invalid direction");
                tryAgain.tryAgainCheckUserShipPosition();
            }

            switch (userShipRichtung) {
                case "N":
                case "n":
                    if(userShipY - userShipLength < 0) {
                        service.rerenderGameField("Invalid Coordinate");
                        tryAgain.tryAgainCheckUserShipPosition();
                        break;
                    } 
                    break;
                case "S": 
                case "s":   
                    if(userShipY + userShipLength > 11) {
                        service.rerenderGameField("Invalid Coordinate");
                        tryAgain.tryAgainCheckUserShipPosition();
                        break;
                    }
                    break;
                case "W":
                case "w":
                    if(userShipX - userShipLength < 0) {
                        service.rerenderGameField("Invalid Coordinate");
                        tryAgain.tryAgainCheckUserShipPosition();
                        break;
                    }
                    break;
                case "O":
                case "o":
                    if(userShipX + userShipLength > 11) {
                        service.rerenderGameField("Invalid Coordinate");
                        tryAgain.tryAgainCheckUserShipPosition();
                        break;
                    }
                    break;
            }
        }


        public static void checkIfUserShip()
        {
            switch (userShipRichtung) {
                case "N":
                case "n":
                    for(int i = 0; i < userShipLength; i++) {
                        if(i == 0)
                        {
                            if(gameField.gameFieldUser[userShipY, userShipX - 1] == "\u25FC " || gameField.gameFieldUser[userShipY, userShipX + 1] == "\u25FC " || gameField.gameFieldUser[userShipY + 1, userShipX] == "\u25FC ") {
                                service.rerenderGameField("Ship already at this Coordinate");
                                tryAgain.tryAgainCheckIfUserShip();
                                break;
                            }
                        } else if (i == (userShipLength - 1)) {
                            if(gameField.gameFieldUser[userShipY - i, userShipX - 1] == "\u25FC " || gameField.gameFieldUser[userShipY - i, userShipX + 1] == "\u25FC " || gameField.gameFieldUser[userShipY - i - 1, userShipX] == "\u25FC ") {
                                service.rerenderGameField("Ship already at this Coordinate");
                                tryAgain.tryAgainCheckIfUserShip();
                                break;
                            }
                        }
                        if (gameField.gameFieldUser[userShipY - i, userShipX] == "\u25FC " || gameField.gameFieldUser[userShipY - i, userShipX - 1] == "\u25FC " || gameField.gameFieldUser[userShipY - i, userShipX + 1] == "\u25FC ")
                        {
                            service.rerenderGameField("Ship already at this Coordinate");
                            tryAgain.tryAgainCheckIfUserShip();
                            break;
                        }
                    }
                    break;       
                case "S":
                case "s":
                    for(int i = 0; i < userShipLength; i++) {
                        if(i == 0)
                        {
                            if(gameField.gameFieldUser[userShipY, userShipX - 1] == "\u25FC " || gameField.gameFieldUser[userShipY, userShipX + 1] == "\u25FC " || gameField.gameFieldUser[userShipY - 1, userShipX] == "\u25FC ") {
                                service.rerenderGameField("Ship already at this Coordinate");
                                tryAgain.tryAgainCheckIfUserShip();
                                break;
                            }
                        } else if (i == (userShipLength - 1)) {
                            if(gameField.gameFieldUser[userShipY + i, userShipX - 1] == "\u25FC " || gameField.gameFieldUser[userShipY + i, userShipX + 1] == "\u25FC " || gameField.gameFieldUser[userShipY + i + 1, userShipX] == "\u25FC ") {
                                service.rerenderGameField("Ship already at this Coordinate");
                                tryAgain.tryAgainCheckIfUserShip();
                                break;
                            }
                        }
                        if (gameField.gameFieldUser[userShipY + i, userShipX] == "\u25FC " || gameField.gameFieldUser[userShipY + i, userShipX - 1] == "\u25FC " || gameField.gameFieldUser[userShipY + i, userShipX + 1] == "\u25FC ")
                        {
                            service.rerenderGameField("Ship already at this Coordinate");
                            tryAgain.tryAgainCheckIfUserShip();
                            break;
                        }
                    }
                    break;
                case "W":
                case "w":
                    for(int i = 0; i < userShipLength; i++) {
                        if(i == 0)
                        {
                            if(gameField.gameFieldUser[userShipY - 1, userShipX] == "\u25FC " || gameField.gameFieldUser[userShipY + 1, userShipX] == "\u25FC " || gameField.gameFieldUser[userShipY, userShipX + 1] == "\u25FC ") {
                                service.rerenderGameField("Ship already at this Coordinate");
                                tryAgain.tryAgainCheckIfUserShip();
                                break;
                            }
                        } else if (i == (userShipLength - 1)) {
                            if(gameField.gameFieldUser[userShipY + 1, userShipX - i] == "\u25FC " || gameField.gameFieldUser[userShipY - 1, userShipX - i] == "\u25FC " || gameField.gameFieldUser[userShipY, userShipX - i - 1] == "\u25FC ") {
                                service.rerenderGameField("Ship already at this Coordinate");
                                tryAgain.tryAgainCheckIfUserShip();
                                break;
                            }
                        }
                        if (gameField.gameFieldUser[userShipY, userShipX - i] == "\u25FC " || gameField.gameFieldUser[userShipY - 1, userShipX - i] == "\u25FC " || gameField.gameFieldUser[userShipY + 1, userShipX - i] == "\u25FC ")
                        {
                            service.rerenderGameField("Ship already at this Coordinate");
                            tryAgain.tryAgainCheckIfUserShip();
                            break;
                        }     
                    }
                    break;
                case "O":
                case "o":
                    for(int i = 0; i < userShipLength; i++) {
                        if(i == 0)
                        {
                            if(gameField.gameFieldUser[userShipY - 1, userShipX] == "\u25FC " || gameField.gameFieldUser[userShipY + 1, userShipX] == "\u25FC " || gameField.gameFieldUser[userShipY, userShipX - 1] == "\u25FC ") {
                                service.rerenderGameField("Ship already at this Coordinate");
                                tryAgain.tryAgainCheckIfUserShip();
                                break;
                            }
                        } else if (i == (userShipLength - 1)) {
                            if(gameField.gameFieldUser[userShipY - 1, userShipX + i] == "\u25FC " || gameField.gameFieldUser[userShipY + 1, userShipX + i] == "\u25FC " || gameField.gameFieldUser[userShipY, userShipX + i + 1] == "\u25FC ") {
                                service.rerenderGameField("Ship already at this Coordinate");
                                tryAgain.tryAgainCheckIfUserShip();
                                break;
                            }
                        }
                        if (gameField.gameFieldUser[userShipY, userShipX + i] == "\u25FC " || gameField.gameFieldUser[userShipY + 1, userShipX] == "\u25FC " || gameField.gameFieldUser[userShipY - 1, userShipX + i] == "\u25FC ")
                        {
                            service.rerenderGameField("Ship already at this Coordinate");
                            tryAgain.tryAgainCheckIfUserShip();
                            break;
                        }    
                    }
                    break;
            }
        }

        public static void setUserShip(int userShipLen)
        {
            userShipLength = userShipLen;
            switch (userShipRichtung) {
                case "N":
                case "n":
                    for(int i = 0; i < userShipLength; i++) {
                        gameField.gameFieldUser[userShipY - i, userShipX] = "\u25FC ";
                    }
                    break;
                case "S":
                case "s":
                    for(int i = 0; i < userShipLength; i++) {
                        gameField.gameFieldUser[userShipY + i, userShipX] = "\u25FC ";
                    }
                    break;
                case "W":
                case "w":
                    for(int i = 0; i < userShipLength; i++) {
                        gameField.gameFieldUser[userShipY, userShipX - i] = "\u25FC ";
                    }
                    break;
                case "O":
                case "o":
                    for(int i = 0; i < userShipLength; i++) {
                        gameField.gameFieldUser[userShipY, userShipX + i] = "\u25FC ";
                    }
                    break;
                }
            Console.Clear();
        }

        public static void getBotShip(int botShipLen)
        {
            botShipLength = botShipLen;
            Random rnd = new Random();
            botShipX = rnd.Next(1, 11);
            botShipY = rnd.Next(1, 11);
            botShipRichtung = rnd.Next(0,4);
        }

        public static void checkBotShipPosition()
        {
            switch (botShipRichtung) {
                case 0:
                    if(botShipY - botShipLength < 0) {
                        tryAgain.tryAgainCheckBotShipPosition();
                        break;
                    }
                    break;
                case 1:
                    if(botShipY + botShipLength > 10) {
                        tryAgain.tryAgainCheckBotShipPosition();
                        break;
                    }
                    break;
                case 2:
                    if(botShipX - botShipLength < 0) {
                        tryAgain.tryAgainCheckBotShipPosition();
                        break;
                    }
                    break;
                case 3:
                    if(botShipX + botShipLength > 10) {
                        tryAgain.tryAgainCheckBotShipPosition();
                        break;
                    }
                    break;
            }
        }

        public static void checkIfBotShip()
        {
            switch (botShipRichtung) {
                case 0:
                    for(int i = 0; i < botShipLength; i++) {
                        if(i == 0)
                        {
                            if(gameField.gameFieldBot[botShipY, botShipX - 1] == "\u25FC " || gameField.gameFieldBot[botShipY, botShipX + 1] == "\u25FC " || gameField.gameFieldBot[botShipY + 1, botShipX] == "\u25FC ") {
                                tryAgain.tryAgainCheckIfBotShip();
                                break;
                            }
                        } else if (i == (botShipLength - 1)) {
                            if(gameField.gameFieldBot[botShipY - i, botShipX - 1] == "\u25FC " || gameField.gameFieldBot[botShipY - i, botShipX + 1] == "\u25FC " || gameField.gameFieldBot[botShipY - i - 1, botShipX] == "\u25FC ") {
                                tryAgain.tryAgainCheckIfBotShip();
                                break;
                            }
                        }
                        if (gameField.gameFieldBot[botShipY - i, botShipX] == "\u25FC " || gameField.gameFieldBot[botShipY - i, botShipX - 1] == "\u25FC " || gameField.gameFieldBot[botShipY - i, botShipX + 1] == "\u25FC ")
                        {
                            tryAgain.tryAgainCheckIfBotShip();
                            break;
                        }     
                    }
                    break;
                case 1:
                    for(int i = 0; i < botShipLength; i++) {
                        if(i == 0)
                        {
                            if(gameField.gameFieldBot[botShipY, botShipX - 1] == "\u25FC " || gameField.gameFieldBot[botShipY, botShipX + 1] == "\u25FC " || gameField.gameFieldBot[botShipY - 1, botShipX] == "\u25FC ") {
                                tryAgain.tryAgainCheckIfBotShip();
                                break;
                            }
                        } else if (i == (botShipLength - 1)) {
                            if(gameField.gameFieldBot[botShipY + i, botShipX - 1] == "\u25FC " || gameField.gameFieldBot[botShipY + i, botShipX + 1] == "\u25FC " || gameField.gameFieldBot[botShipY + i + 1, botShipX] == "\u25FC ") {
                                tryAgain.tryAgainCheckIfBotShip();
                                break;
                            }
                        }     
                        if (gameField.gameFieldBot[botShipY + i, botShipX] == "\u25FC " || gameField.gameFieldBot[botShipY + i, botShipX - 1] == "\u25FC " || gameField.gameFieldBot[botShipY + i, botShipX + 1] == "\u25FC ")
                        {
                            tryAgain.tryAgainCheckIfBotShip();
                            break;
                        }  
                    }
                    break;
                case 2:
                    for(int i = 0; i < botShipLength; i++) {
                        if(i == 0)
                        {
                            if(gameField.gameFieldBot[botShipY - 1, botShipX] == "\u25FC " || gameField.gameFieldBot[botShipY + 1, botShipX] == "\u25FC " || gameField.gameFieldBot[botShipY, botShipX + 1] == "\u25FC ") {
                                tryAgain.tryAgainCheckIfBotShip();
                                break;
                            }
                        } else if (i == (botShipLength - 1)) {
                            if(gameField.gameFieldBot[botShipY + 1, botShipX - i] == "\u25FC " || gameField.gameFieldBot[botShipY - 1, botShipX - i] == "\u25FC " || gameField.gameFieldBot[botShipY, botShipX - i - 1] == "\u25FC ") {
                                tryAgain.tryAgainCheckIfBotShip();
                                break;
                            }
                        }
                        if (gameField.gameFieldBot[botShipY, botShipX - i] == "\u25FC " || gameField.gameFieldBot[botShipY - 1, botShipX - i] == "\u25FC " || gameField.gameFieldBot[botShipY + 1, botShipX - i] == "\u25FC ")
                        {
                            tryAgain.tryAgainCheckIfBotShip();
                            break;
                        }       
                    }
                    break;
                case 3:
                    for(int i = 0; i < botShipLength; i++) {
                        if(i == 0)
                        {
                            if(gameField.gameFieldBot[botShipY - 1, botShipX] == "\u25FC " || gameField.gameFieldBot[botShipY + 1, botShipX] == "\u25FC " || gameField.gameFieldBot[botShipY, botShipX - 1] == "\u25FC ") {
                                tryAgain.tryAgainCheckIfBotShip();
                                break;
                            }
                        } else if (i == (botShipLength - 1)) {
                            if(gameField.gameFieldBot[botShipY - 1, botShipX + i] == "\u25FC " || gameField.gameFieldBot[botShipY + 1, botShipX + i] == "\u25FC " || gameField.gameFieldBot[botShipY, botShipX + i + 1] == "\u25FC ") {
                                tryAgain.tryAgainCheckIfBotShip();
                                break;
                            }
                        }
                        if (gameField.gameFieldBot[botShipY, botShipX + i] == "\u25FC " || gameField.gameFieldBot[botShipY - 1, botShipX + i] == "\u25FC " || gameField.gameFieldBot[botShipY + 1, botShipX + i] == "\u25FC ")
                        {
                            tryAgain.tryAgainCheckIfBotShip();
                            break;
                        }  
                    }
                    break;
            }
        }
        public static void setBotShip(int botShipLen)
        {
            botShipLength = botShipLen;
            switch (botShipRichtung) {
                case 0:
                    for(int i = 0; i < botShipLength; i++) {
                        gameField.gameFieldBot[botShipY - i, botShipX] = "\u25FC ";
                    }
                    break;
                case 1:
                    for(int i = 0; i < botShipLength; i++) {
                        gameField.gameFieldBot[botShipY + i, botShipX] = "\u25FC ";
                    }
                    break;
                case 2:
                    for(int i = 0; i < botShipLength; i++) {
                        gameField.gameFieldBot[botShipY, botShipX - i] = "\u25FC ";
                    }
                    break;
                case 3:
                    for(int i = 0; i < botShipLength; i++) {
                        gameField.gameFieldBot[botShipY, botShipX + i] = "\u25FC ";
                    }
                    break;
            }
        }
    }
}
