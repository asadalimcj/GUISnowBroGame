using PacMan.GameGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManGUI.GameGL
{
    internal class Collision
    {
        public static bool EnemyDetection(GameCell cell)
        {
            if (cell.CurrentGameObject.GameObjectType == GameObjectType.ENEMY)
            {
                return true;
            }
            return false;
        }
        public static bool WallDetection(GameCell cell)
        {
            if (cell.CurrentGameObject.GameObjectType == GameObjectType.WALL)
            {
                return true;
            }
            return false;
        }
        public static bool PlayerDetection(GameCell cell)
        {
            if (cell.CurrentGameObject.GameObjectType == GameObjectType.PLAYER)
            {
                return true;
            }
            return false;
        }
    }
}
