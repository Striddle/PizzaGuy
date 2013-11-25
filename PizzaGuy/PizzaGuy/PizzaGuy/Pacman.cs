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
    class Pacman : MazeGuy
    {
        private void HandleKeyboardInput(KeyboardState keyState)
        {
            Pacman.origin = Pacman.Location;
            if (keyState.IsKeyDown(Keys.Up))
            {
                // direction
                Pacman.direction = Direction.UP;

            }

            else if (keyState.IsKeyDown(Keys.Down))
            {
                Pacman.direction = Direction.DOWN;
            }

            else if (keyState.IsKeyDown(Keys.Left))
            {
                Pacman.direction = Direction.LEFT;
            }

            else if (keyState.IsKeyDown(Keys.Right))
            {
                Pacman.direction = Direction.RIGHT;
            }
        }
    }
}
