using GameDev_project.Gamescreen;
using GameDev_project.Interfaces;
using GameDev_project.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Timers;

namespace GameDev_project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D background;
        Texture2D pressEnter;
        Texture2D dinoHead;
        Texture2D title;
        Texture2D blokTexture;
        Rectangle obstakel;
        Player player;
        StartScreen startscreen;
        IInputReader inputReader;
        Vector2 positie = new Vector2(0,0);

        public enum Gamestates { Start, FirstLevel, FinalLevel, GameOver, Goal }
        public static Gamestates currentState;
 
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            player = new Player(blokTexture, inputReader);
            obstakel = new Rectangle(400, 400, 30, 30);
            startscreen = new StartScreen(background, title, dinoHead, pressEnter);
        }

        protected override void LoadContent()
        {
            blokTexture = new Texture2D(GraphicsDevice, 1, 1);
            blokTexture.SetData(new[] { Color.White });
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            inputReader = new KeyboardReader();
            background = Content.Load<Texture2D>("startscreen");
            pressEnter = Content.Load<Texture2D>("press-enter");
            dinoHead = Content.Load<Texture2D>("dinohead");
            title = Content.Load<Texture2D>("title");
            // TODO: use this.Content to load your game content here
            currentState = Gamestates.Start;

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Update(gameTime);
            startscreen.Update(gameTime);
            base.Update(gameTime);
            ChangeGameState();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            // TODO: Add your drawing code here
            if (currentState == Gamestates.Start)
                startscreen.Draw(_spriteBatch);
           
            if (currentState == Gamestates.FirstLevel)
            {
                player.Draw(_spriteBatch);
                _spriteBatch.Draw(blokTexture, new Rectangle(400, 400, 30, 30), Color.Black);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public void ChangeGameState()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                currentState = Gamestates.FirstLevel;

        }
    }
}