using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace PacMan.GameGL
{
    public class Game
    {
        public static GameObject getBlankGameObject()
        {
            GameObject blankGameObject = new GameObject(GameObjectType.NONE, null);
            return blankGameObject;
        }

        public static GameObject getRewardGameObject()
        {
            GameObject blankGameObject = new GameObject(GameObjectType.REWARD, PacManGUI.Properties.Resources.pallet);
            return blankGameObject;
        }
        public static Image getGameObjectImage(char displayCharacter)
        {
            Image img = null;
            if (displayCharacter == '%')
            {
                img = PacManGUI.Properties.Resources.wallOne;
            }
            if (displayCharacter == '|')
            {
                img = PacManGUI.Properties.Resources._1234;
            }



            if (displayCharacter == '#')
            {
                img = PacManGUI.Properties.Resources.wallTwo_removebg_preview;
            }

            if (displayCharacter == 'B')
            {
                img = PacManGUI.Properties.Resources.enemyballs;
            }
            if (displayCharacter == 'b')
            {
                img = PacManGUI.Properties.Resources.horizontalBalls;
            }

            if (displayCharacter == '.')
            {
                img = PacManGUI.Properties.Resources.pallet;
            }


            if (displayCharacter == '-')
            {
                img = PacManGUI.Properties.Resources._123;
            }
            if (displayCharacter == 'O')
            {
                img = PacManGUI.Properties.Resources.snowBalls;
            }

            if (displayCharacter == '+')
            {
                img = PacManGUI.Properties.Resources._1234;
            }
            if (displayCharacter == 'P' || displayCharacter == 'p') {
                img = PacManGUI.Properties.Resources.snowbro;
            }
            if (displayCharacter == 'G' || displayCharacter == 'g')
            {
                img = PacManGUI.Properties.Resources.enemyHorizontal;
            }
            if(displayCharacter == 'H' || displayCharacter == 'h')
            {
                img = PacManGUI.Properties.Resources.enemyRandom;
            }
            if (displayCharacter == 'R' || displayCharacter == 'r')
            {
                img = PacManGUI.Properties.Resources.enemyVertical;
            }
            if (displayCharacter == 'S' || displayCharacter == 's')
            {
                img = PacManGUI.Properties.Resources.enemyVertical;
            }

            return img;
        }
    }
}
