using PacMan.GameGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManGUI.GameGL
{
    internal class Bullets : GameObject
    {
        GameDirection BDirection;
        GameObject previous = Game.getBlankGameObject();
        public Bullets(GameObjectType type, Image image, GameCell cell, GameDirection direction) : base(type, image)
        {
            this.CurrentCell = cell;
            BDirection = direction;
        }
        public GameDirection Direction { get { return BDirection; } }
        public GameCell Move()
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(BDirection);
            GameCell nextCopy = new GameCell(nextCell.X, nextCell.Y, nextCell.gameGrid);
            nextCopy.setGameObject(nextCell.CurrentGameObject);
            GameObject nextObject = nextCell.CurrentGameObject;
            this.CurrentCell = nextCell;
            if (nextCell != null && currentCell != nextCell)
            {
                if (previous.GameObjectType == GameObjectType.REWARD)
                {
                    currentCell.setGameObject(Game.getRewardGameObject());
                }
                else if (previous.GameObjectType == GameObjectType.NONE)
                {
                    currentCell.setGameObject(Game.getBlankGameObject());
                }
                previous = nextObject;

            }
            else
            {
                currentCell.setGameObject(Game.getBlankGameObject());
            }
            return nextCopy;
        }
    }
}
