using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PacMan.GameGL;
using EZInput;
using PacManGUI.GameGL;

namespace PacManGUI
{
    public partial class Form1 : Form
    {
        GameGrid grid;
        int score = 0;
        GamePacManPlayer pacman;
        VerticalGhost G1;
        HorizontalGhost H1;
        RandomGhost R1;
        GameCell right;
        int smartcount = 0;
        int enemyBulletDelay = 0;
        List<Ghosts> ghosts = new List<Ghosts>();
        List<Bullets> bullets = new List<Bullets>();
        List<Bullets> enemyBullets = new List<Bullets>();
        public Form1()
        {
            InitializeComponent();
        }

       
        
        private void Form1_Load(object sender, EventArgs e)
        {
            grid = new GameGrid("maze1.txt", 17, 31);
            Image pacManImage = Game.getGameObjectImage('P');
            GameCell startCell = grid.getCell(12, 8);
            pacman = new GamePacManPlayer(pacManImage, startCell);
            Image VerticalGhost = Game.getGameObjectImage('G');
            GameCell VGostCell = grid.getCell(9, 17);
            G1 = new VerticalGhost(VerticalGhost, VGostCell);
            Image HorizontalghostImage = Game.getGameObjectImage('H');
            GameCell HGhostCell = grid.getCell(4, 2);
            H1 = new HorizontalGhost(HorizontalghostImage, HGhostCell);
            Image randomGhostImage = Game.getGameObjectImage('R');
            GameCell RGhostCell = grid.getCell(5, 20);
            R1 = new RandomGhost(randomGhostImage, RGhostCell);
            ghosts.Add(G1);
            ghosts.Add(H1);
            ghosts.Add(R1);
            printMaze(grid);
        }



        void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {
               
                for (int y = 0; y < grid.Cols; y++)
                {
                    GameCell cell = grid.getCell(x, y);
                    this.Controls.Add(cell.PictureBox);          
            //        printCell(cell);
                }

            }
        }

        void generatePlayerBullet()
        {
            Image bImage = Game.getGameObjectImage('O');
            GameCell bCell = grid.getCell(pacman.CurrentCell.X, pacman.CurrentCell.Y + 1);
            Bullets bullet = new Bullets(GameObjectType.BULLET, bImage, bCell, GameDirection.Right);
            bullets.Add(bullet);
        }

        void generateVerticalBullets()
        {
            Image bImage = Game.getGameObjectImage('B');
            GameCell bCell = grid.getCell(G1.CurrentCell.X, G1.CurrentCell.Y - 1);
            Bullets bullet = new Bullets(GameObjectType.BULLET, bImage, bCell, GameDirection.Left);
            enemyBullets.Add(bullet);
        }

        void generateHorizontalBullets()
        {
            Image bImage = Game.getGameObjectImage('b');
            GameCell bCell = grid.getCell(H1.CurrentCell.X + 1, H1.CurrentCell.Y);
            Bullets bullet = new Bullets(GameObjectType.BULLET, bImage, bCell, GameDirection.Down);
            enemyBullets.Add(bullet);
        }

        static void printCell(GameCell cell)
        {
            Console.SetCursorPosition(cell.Y, cell.X);
            Console.Write(cell.CurrentGameObject.DisplayCharacter);
        }
     

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            if(Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                GameCell cell = pacman.move(GameDirection.Left);
                if (Collision.EnemyDetection(cell))
                {
                    DecreasePlayerHealth();
                }
            }
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                GameCell cell = pacman.move(GameDirection.Right);
                if (Collision.EnemyDetection(cell))
                {
                    DecreasePlayerHealth();
                }
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                GameCell cell =  pacman.move(GameDirection.Up);
                if (Collision.EnemyDetection(cell))
                {
                    DecreasePlayerHealth();
                }
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                GameCell cell =  pacman.move(GameDirection.Down);
                if (Collision.EnemyDetection(cell))
                {
                    DecreasePlayerHealth();
                }
            }

            if (Keyboard.IsKeyPressed(Key.Space))
            {
                generatePlayerBullet();
            }

            
            
            foreach (var a in ghosts)
            {
                GameCell cell =  a.Move();
                if (Collision.PlayerDetection(cell))
                {
                    DecreasePlayerHealth();
                }
            }
            
            if(enemyBulletDelay == 10)
            {
                generateVerticalBullets();
                generateHorizontalBullets();
                enemyBulletDelay = 0;
            }
            MovePlayerBullets();
            MoveEnemyBullets();
            smartcount++;
            enemyBulletDelay++;
            GameOver();
        }

        private void lblScore_Click(object sender, EventArgs e)
        {

        }

        private void MovePlayerBullets()
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                GameCell cell = bullets[i].Move();
                if (Collision.EnemyDetection(cell))
                {
                    IncreaseScore();
                    bullets.Remove(bullets[i]);

                }
                else if (Collision.WallDetection(cell))
                {
                    bullets.Remove(bullets[i]);

                }
            }
        }

        private void MoveEnemyBullets()
        {
            for (int i = 0; i < enemyBullets.Count; i++)
            {
                GameCell cell = enemyBullets[i].Move();
                if (Collision.PlayerDetection(cell))
                {
                    DecreasePlayerHealth();
                    enemyBullets.Remove(enemyBullets[i]);
                }
                else if (Collision.WallDetection(cell))
                {
                    enemyBullets.Remove(enemyBullets[i]);
                }
            }
        }


        private void IncreaseScore()
        {
            score++;
            lblScore.Text = "Score" + score;
        }

        private void DecreasePlayerHealth()
        {
            Healthbar.Value -= 10;
        }

        private void Healthbar_Click(object sender, EventArgs e)
        {

        }

        private void GameOver()
        {
            if (Healthbar.Value <= 0)
            {
                gameLoop.Enabled = false;
                this.Hide();
                Form gameOver = new GameOver();
                gameOver.ShowDialog();
                this.Show();
            }

        }
    }
}
