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


    /// <summary>
    /// This is the main type for your game
    /// thanks.
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D PacmanSheet;
        PizzaGuy pacman;
        Map map;
        Map dots;
        IDisplayDevice mapDisplayDevice;
        xTile.Dimensions.Rectangle viewport;

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
            mapDisplayDevice = new XnaDisplayDevice(Content, GraphicsDevice);

            viewport = new xTile.Dimensions.Rectangle(new xTile.Dimensions.Size(800, 480));

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

            map = Content.Load<Map>("Map");
           // map = Content.Load<Map>("Dots");
            map.LoadTileSheets(mapDisplayDevice);
            //map.AddLayer(xTile.Layers.Layer("dots"));

            PacmanSheet = Content.Load<Texture2D>("PacmanSprites");

            pacman = new PizzaGuy(new Vector2(340, 300), PacmanSheet, new Rectangle(120, 22, 30, 30), new Vector2(32, 0));
            pacman.AddFrame(new Rectangle(18, 22, 30, 30));
            pacman.AddFrame(new Rectangle(74, 22, 30, 30));
            pacman.AddFrame(new Rectangle(18, 22, 30, 30));

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

        //game window is 800 x 480

        public void UpdateDirection()
        {
            switch (pacman.direction)
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

        private void HandleKeyboardInput(KeyboardState keyState)
        {
            pacman.origin = pacman.Location;
            if (keyState.IsKeyDown(Keys.Up))
            {
                // direction
                pacman.direction = Direction.UP;

            }

            else if (keyState.IsKeyDown(Keys.Down))
            {
                pacman.direction = Direction.DOWN;
            }

            else if (keyState.IsKeyDown(Keys.Left))
            {
                pacman.direction = Direction.LEFT;
            }

            else if (keyState.IsKeyDown(Keys.Right))
            {
                pacman.direction = Direction.RIGHT;
            }




            if (pacman.Velocity.X > 0 && pacman.Location.X >= pacman.destination.X ||
                pacman.Velocity.X < 0 && pacman.Location.X <= pacman.destination.X ||
                pacman.Velocity.Y > 0 && pacman.Location.Y >= pacman.destination.Y ||
                pacman.Velocity.Y < 0 && pacman.Location.Y <= pacman.destination.Y ||
                pacman.Velocity.X > 0 && pacman.direction == Direction.LEFT ||
                pacman.Velocity.X < 0 && pacman.direction == Direction.RIGHT ||
                pacman.Velocity.Y > 0 && pacman.direction == Direction.UP ||
                pacman.Velocity.Y < 0 && pacman.direction == Direction.DOWN)
            {
                UpdateDirection();
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
            GraphicsDevice.Clear(Color.Black);

            map.Draw(mapDisplayDevice, viewport);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            pacman.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);

        }
    }
}
