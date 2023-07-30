using PacMan.GameGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManGUI.GameGL
{
    class RandomGhost : Ghosts
    {
        public GameDirection direction = GameDirection.Down;
        public RandomGhost(Image image, GameCell startCell) : base(image, startCell)
        {

        }

        public int GetRandomDirection()
        {
            Random rnd = new Random();
            int num = rnd.Next(4);
            return num;
        }

        public override GameCell Move()
        {
            int dir = GetRandomDirection();
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(direction);
            GameCell temp = new GameCell(nextCell.X, nextCell.Y, nextCell.gameGrid);
            temp.setGameObject(nextCell.CurrentGameObject);
            GameObject nextObject = nextCell.CurrentGameObject;
            this.CurrentCell = nextCell;
            if (currentCell != nextCell)
            {
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
            }

            if (dir == 0)
            {
                direction = GameDirection.Up;
            }
            else if (dir == 1)
            {
                direction = GameDirection.Down;
            }
            else if (dir == 2)
            {
                direction = GameDirection.Left;
            }
            else if (dir == 3)
            {
                direction = GameDirection.Right;
            }
            return temp;

        }
    }
}
