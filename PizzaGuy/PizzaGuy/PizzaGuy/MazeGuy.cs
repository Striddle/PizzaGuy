using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using xTile;
using xTile.Display;

namespace PizzaGuy
{
    class MazeGuy : Sprite
    {
        public void UpdateDirection()
        {
            switch (MazeGuy.direction)
            {
                case Direction.UP:
                    pacman.Velocity = new Vector2(0, -100);
                    pacman.Rotation = MathHelper.PiOver2;
                    pacman.destination = pacman.Location - new Vector2(0, 32);
                    break;

                case Direction.DOWN:
                    pacman.Velocity = new Vector2(0, 100);
                    pacman.Rotation = -MathHelper.PiOver2;
                    pacman.destination = pacman.Location + new Vector2(0, 32);
                    break;

                case Direction.LEFT:
                    pacman.Velocity = new Vector2(-100, 0);
                    pacman.Rotation = 0f;
                    pacman.destination = pacman.Location - new Vector2(32, 0);
                    break;

                case Direction.RIGHT:
                    pacman.Velocity = new Vector2(100, 0);
                    pacman.Rotation = MathHelper.Pi;
                    pacman.destination = pacman.Location + new Vector2(32, 0);
                    break;
            }
        }

    }
}
