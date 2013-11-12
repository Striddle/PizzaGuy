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
using System.Text;


namespace PizzaGuy
{
    class Sprite
    {

        public Sprite(
            Vector2 location,
            Texture2D texture,
            Rectangle initialframe,
            Vector2 velocity);

        public virtual void Update(GameTime Gametime);
    }
}
