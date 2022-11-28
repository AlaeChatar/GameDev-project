using GameDev_project.Characters;
using GameDev_project.Gamescreens;
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
        
        // Startscreen resources
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

        // Characters
        Texture2D blokTexture;
        Rectangle obstakel;
        Player player;
        IInputReader inputReader;
        Vector2 positie = new Vector2(0, 0);

        // Screens
        ScreenManager screenManager;
        StartScreen startScreen;
        FirstLevel firstLevel;
 
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
            startScreen = new StartScreen(startScreenBackground, dinoHead, woodenPlank, titleFont, pressEnterFont);
            firstLevel = new FirstLevel(firstLevelBackground1, firstLevelBackground2, firstLevelBackground3, firstLevelBackground4, firstLevelBackground5);
            screenManager = new ScreenManager(player, blokTexture, startScreen, firstLevel);
        }

        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
            blokTexture = new Texture2D(GraphicsDevice, 1, 1);
            blokTexture.SetData(new[] { Color.White });
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            inputReader = new KeyboardReader();
            startScreenBackground = Content.Load<Texture2D>("Startscreen/karina-formanova-rainforest-animation");
            dinoHead = Content.Load<Texture2D>("Startscreen/dinohead");
            woodenPlank = Content.Load<Texture2D>("Startscreen/wooden-plank");
            titleFont = Content.Load<SpriteFont>("Startscreen/title-font");
            pressEnterFont = Content.Load<SpriteFont>("Startscreen/pressenter-font");
            firstLevelBackground1 = Content.Load<Texture2D>("FirstLevel/plx-1");
            firstLevelBackground2 = Content.Load<Texture2D>("FirstLevel/plx-2");
            firstLevelBackground3 = Content.Load<Texture2D>("FirstLevel/plx-3");
            firstLevelBackground4 = Content.Load<Texture2D>("FirstLevel/plx-4");
            firstLevelBackground5 = Content.Load<Texture2D>("FirstLevel/plx-5");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            screenManager.Update(gameTime);
            base.Update(gameTime);

            if (obstakel.Intersects(player))
            {

            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Olive);
            _spriteBatch.Begin();
            // TODO: Add your drawing code here
            screenManager.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}