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
        Texture2D startScreenBackground;
        Texture2D firstLevelBackground1;
        Texture2D firstLevelBackground2;
        Texture2D firstLevelBackground3;
        Texture2D firstLevelBackground4;
        Texture2D firstLevelBackground5;
        Texture2D woodenPlank;
        Texture2D dinoHead;
        SpriteFont titleFont;
        SpriteFont pressEnterFont;
        Texture2D blokTexture;
        Rectangle obstakel;
        Player player;
        StartScreen startscreen;
        FirstLevel firstLevel;
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
            startscreen = new StartScreen(startScreenBackground, dinoHead, woodenPlank, titleFont, pressEnterFont);
            firstLevel = new FirstLevel(firstLevelBackground1, firstLevelBackground2, firstLevelBackground3, firstLevelBackground4, firstLevelBackground5);
        }

        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
            blokTexture = new Texture2D(GraphicsDevice, 1, 1);
            blokTexture.SetData(new[] { Color.White });
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            inputReader = new KeyboardReader();
            startScreenBackground = Content.Load<Texture2D>("startscreen");
            dinoHead = Content.Load<Texture2D>("dinohead");
            woodenPlank = Content.Load<Texture2D>("wooden-plank");
            titleFont = Content.Load<SpriteFont>("title-font");
            pressEnterFont = Content.Load<SpriteFont>("pressenter-font");
            firstLevelBackground1 = Content.Load<Texture2D>("plx-1");
            firstLevelBackground2 = Content.Load<Texture2D>("plx-2");
            firstLevelBackground3 = Content.Load<Texture2D>("plx-3");
            firstLevelBackground4 = Content.Load<Texture2D>("plx-4");
            firstLevelBackground5 = Content.Load<Texture2D>("plx-5");
            currentState = Gamestates.Start;

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Update(gameTime);
            startscreen.Update(gameTime);
            firstLevel.Update(gameTime);
            base.Update(gameTime);
            ChangeGameState();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Olive);
            _spriteBatch.Begin();
            // TODO: Add your drawing code here
            if (currentState == Gamestates.Start)
                startscreen.Draw(_spriteBatch);
           
            if (currentState == Gamestates.FirstLevel)
            {
                firstLevel.Draw(_spriteBatch);
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