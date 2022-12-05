using GameDev_project.Characters;
using GameDev_project.Gamescreens;
using GameDev_project.Interfaces;
using GameDev_project.Map;
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

        //GameOver resources
        Texture2D endScreen;

        // Characters
        Texture2D blokTexture;
        Player player;
        IInputReader inputReader;
        Vector2 positie = new Vector2(0, 0);
        Boss boss;
        Enemy enemy;

        // Screens
        ScreenManager screenManager;
        StartScreen startScreen;
        FirstLevel firstLevel;
        FinalLevel finalLevel;
        Goal goal;
        GameOver gameOver;

        //Environment
        Block block;
        TileSet tileSet;

 
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
            startScreen = new StartScreen(startScreenBackground, dinoHead, woodenPlank, titleFont, pressEnterFont);
            firstLevel = new FirstLevel(firstLevelBackground1, firstLevelBackground2, firstLevelBackground3, firstLevelBackground4, firstLevelBackground5);
            finalLevel = new FinalLevel();
            goal = new Goal();
            gameOver = new GameOver(endScreen);
            screenManager = new ScreenManager(player, enemy, boss, blokTexture, startScreen, firstLevel, finalLevel, goal, gameOver);
            block = new Block();
            tileSet = new TileSet(blokTexture);
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
            endScreen = Content.Load<Texture2D>("EndScreen/gameover");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            screenManager.Update(gameTime);
            base.Update(gameTime);
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