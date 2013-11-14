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

namespace PizzaGuy
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D PacmanSheet;
        PizzaGuy pacman;
        Vector2 destination;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            PacmanSheet = Content.Load<Texture2D>("PacmanSprites");

            pacman = new PizzaGuy(new Vector2(300, 300), PacmanSheet, new Rectangle(114, 13, 38, 39), Vector2.Zero);
            pacman.AddFrame(new Rectangle(18, 14, 34, 37));
            pacman.AddFrame(new Rectangle(74, 13, 27, 38));
            pacman.AddFrame(new Rectangle(18, 14, 34, 37));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 


        private void HandleKeyboardInput(KeyboardState keyState)
        {

            if (keyState.IsKeyDown(Keys.Up))
            {
                pacman.Velocity = new Vector2(0, -100);
                pacman.Rotation = MathHelper.PiOver2;
                destination = pacman.Location - new Vector2(0, 32);
                
            }

            else if(keyState.IsKeyDown(Keys.Down))
            {
                pacman.Velocity = new Vector2(0, 100);
                pacman.Rotation = -MathHelper.PiOver2 ;
            }

            else if (keyState.IsKeyDown(Keys.Left))
            {
                pacman.Velocity = new Vector2(-100, 0);
                pacman.Rotation = 0;
            }

            else if (keyState.IsKeyDown(Keys.Right))
            {
                pacman.Velocity = new Vector2(100, 0);
                pacman.Rotation = MathHelper.Pi;
            }
            if (pacman.Location == destination)
            {
                pacman.Velocity = new Vector2(0, 0);
            }

            imposeMovementLimits();
        }

        private void imposeMovementLimits()
        {
            Vector2 location = pacman.Location;

            if (location.X < 0)
                location.X = 0;

            if (location.X >
                (800 - pacman.Source.Width))
                location.X =
                    (800 - pacman.Source.Width);

            if (location.Y < 0)
                location.Y = 0;

            if (location.Y >
                (480 - pacman.Source.Height))
                location.Y =
                    (480 - pacman.Source.Height);

            pacman.Location = location;
        }




        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            HandleKeyboardInput(Keyboard.GetState());
            pacman.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            pacman.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);

        }
    }
}
