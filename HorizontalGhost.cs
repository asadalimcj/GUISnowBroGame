using PacMan.GameGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManGUI.GameGL
{
    class HorizontalGhost : Ghosts
    {
        public GameDirection direction = GameDirection.Right;
        public HorizontalGhost(Image image, GameCell startCell) : base(image, startCell)
        {

        }
        public override GameCell Move()
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(direction);
            GameCell temp = new GameCell(nextCell.X, nextCell.Y, nextCell.gameGrid);
            temp.setGameObject(nextCell.CurrentGameObject);
            GameObject nextObject = nextCell.CurrentGameObject;
            this.CurrentCell = nextCell;
            if (currentCell != nextCell)
            {
                if (previous.GameObjectType == GameObjectType.REWARD)
                {
                    currentCell.setGameObject(Game.getRewardGameObject());
                }
                else
                {
                    currentCell.setGameObject(Game.getBlankGameObject());
                }
                previous = nextObject;
            }
            else
            {
                ChangeDirection();
            }
            return temp;
        }

        public void ChangeDirection()
        {
            if (direction == GameDirection.Right)
            {
                direction = GameDirection.Left;
            }
            else if (direction == GameDirection.Left)
            {
                direction = GameDirection.Right;
            }
        }
    }
}
