using PacMan.GameGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManGUI.GameGL
{
    abstract class Ghosts : GameObject
    {
        public abstract GameCell Move();
        public GameObject previous = Game.getBlankGameObject();
        public Ghosts(GameObjectType type, Image image) : base(type, image)
        {

        }
        public Ghosts(GameObjectType type, char displayCharacter) : base(type, displayCharacter)
        {

        }
        public Ghosts(Image pic, GameCell cell) : base(pic, cell)
        {
            
        }
    }
}
