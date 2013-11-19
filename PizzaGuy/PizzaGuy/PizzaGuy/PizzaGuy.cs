using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PizzaGuy
{
    enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }


    class PizzaGuy : Sprite
    {
        public Direction direction;
        public Vector2 destination;
        public Vector2 origin;
        public PizzaGuy(
            Vector2 location,
            Texture2D texture,
            Rectangle initialFrame,
            Vector2 velocity)
            : base(location, texture, initialFrame, velocity)
        {

        }



        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }


    }

}
