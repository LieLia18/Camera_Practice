using CameraNS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprites;

namespace Camera_Practice
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D _background;
        Texture2D _body;
        private SimpleSprite sprite;
        Camera Cam;
        Vector2 WorldBound = new Vector2(4000, 3000);
        Rectangle WorldRectangle;
        float speed = 5.0f;
        

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
            _background = Content.Load<Texture2D>("background");
            _body = Content.Load<Texture2D>("body");
            sprite = new SimpleSprite(_body, 
            GraphicsDevice.Viewport.Bounds.Center.ToVector2());
            Cam = new Camera(Vector2.Zero,
                WorldBound
                );
            WorldRectangle = new Rectangle(Point.Zero, WorldBound.ToPoint());

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                Cam.move(new Vector2(1, 0) * speed, GraphicsDevice.Viewport);
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                Cam.move(new Vector2(-1, 0) * speed, GraphicsDevice.Viewport);
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                Cam.move(new Vector2(0, -1) * speed, GraphicsDevice.Viewport);
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                Cam.move(new Vector2(0, 1) * speed, GraphicsDevice.Viewport);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.BackToFront,
                                 BlendState.AlphaBlend,
                                 null, null, null, null, Cam.CurrentCameraTranslation);
            spriteBatch.Draw(_background, WorldRectangle, Color.White);
            spriteBatch.End();




            base.Draw(gameTime);
        }
    }
}
