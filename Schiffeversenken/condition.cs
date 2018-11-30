using System;

namespace Schiffeversenken
{
    public class tryAgain
    {
        public static void tryAgainCheckIfUserShip()
        {
            ship.getUserShip(ship.userShipLength);
            ship.checkUserShipPosition();
            ship.checkIfUserShip();
        }

        public static void tryAgainCheckUserShipPosition()
        {
            ship.getUserShip(ship.userShipLength);
        }

        public static void tryAgainUserAttack()
        {
            user.Attack();
        }

        public static void tryAgainCheckIfBotShip()
        {
            ship.getBotShip(ship.botShipLength);
            ship.checkBotShipPosition();
            ship.checkIfBotShip();
        }

        public static void tryAgainCheckBotShipPosition()
        {
            ship.getBotShip(ship.botShipLength);
            ship.checkBotShipPosition();            
        }

        public static void tryAgainBotAttack()
        {
            bot.Attack();
        }
    }
}
