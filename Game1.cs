using GameDev_project.Animations;
using GameDev_project.Gamescreens;
using GameDev_project.Map;
using GameDev_project.Objects;
using GameDev_project.Objects.Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Timers;
using static GameDev_project.Gamescreens.ScreenManager;

namespace GameDev_project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        // Screen resources
        Texture2D startScreenBackground;
        Texture2D background1;
        Texture2D background2;
        Texture2D background3;
        Texture2D background4;
        Texture2D background5;
        Texture2D woodenPlank;
        Texture2D dinoHead;
        SpriteFont titleFont;
        SpriteFont pressEnterFont;
        Texture2D youLose;
        Texture2D youWin;

        // Sprites
        Texture2D blokTexture;
        List<Texture2D> heroTextures = new List<Texture2D>();
        List<Texture2D> walkerTextures = new List<Texture2D>();
        List<Texture2D> jumperTextures = new List<Texture2D>();
        List<Texture2D> gateTextures = new List<Texture2D>();

        // Objects
        Hero hero1;
        Hero hero2;
        List<Enemy> enemiesLevel1 = new List<Enemy>();
        List<Enemy> enemiesLevel2 = new List<Enemy>();
        List<Lava> lava1 = new List<Lava>();
        List<Lava> lava2 = new List<Lava>();
        List<Item> eggs1 = new List<Item>();
        List<Item> eggs2 = new List<Item>();
        Item gate;

        // Screens
        ScreenManager screenManager;
        Start startScreen;
        Level levelOne;
        Level levelTwo;
        Goal goal;
        GameOver gameOver;

        //Map
        TileSet tileSet1;
        TileSet tileSet2;

        Camera camera;

 
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 960;
            _graphics.PreferredBackBufferHeight = 540;
            _graphics.IsFullScreen = false;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            // Map
            tileSet1 = new TileSet();
            tileSet2 = new TileSet();
            base.Initialize();

            // Player
            hero1 = new Hero(heroTextures, new Vector2(100, 900));
            hero2 = new Hero(heroTextures, new Vector2(10, 420));

            // Enemies
            enemiesLevel1.Add(new Walker(walkerTextures, new Vector2(430, 900)));
            enemiesLevel1.Add(new Walker(walkerTextures, new Vector2(60, 420)));
            enemiesLevel1.Add(new Walker(walkerTextures, new Vector2(1400, 420)));
            enemiesLevel1.Add(new Jumper(jumperTextures, new Vector2(1020, 1080)));
            enemiesLevel2.Add(new Walker(walkerTextures, new Vector2(1380, 480)));
            enemiesLevel2.Add(new Walker(walkerTextures, new Vector2(1470, 630)));
            enemiesLevel2.Add(new Walker(walkerTextures, new Vector2(800, 750)));
            enemiesLevel2.Add(new Jumper(jumperTextures, new Vector2(840, 300)));
            enemiesLevel2.Add(new Jumper(jumperTextures, new Vector2(1020, 390)));
            enemiesLevel2.Add(new Jumper(jumperTextures, new Vector2(1200, 300)));
            enemiesLevel2.Add(new Jumper(jumperTextures, new Vector2(1380, 390)));
            enemiesLevel2.Add(new Jumper(jumperTextures, new Vector2(1090, 990)));
            enemiesLevel2.Add(new Jumper(jumperTextures, new Vector2(700, 1080)));
            enemiesLevel2.Add(new Jumper(jumperTextures, new Vector2(570, 1050)));
            enemiesLevel2.Add(new Jumper(jumperTextures, new Vector2(330, 1020)));

            // Lava
            lava1.Add(new Lava(blokTexture, new Vector2(965, 920), 110, 30));
            lava2.Add(new Lava(blokTexture, new Vector2(815, 260), 80, 30));
            lava2.Add(new Lava(blokTexture, new Vector2(995, 260), 80, 30));
            lava2.Add(new Lava(blokTexture, new Vector2(1175, 260), 80, 30));
            lava2.Add(new Lava(blokTexture, new Vector2(1355, 260), 80, 30));
            lava2.Add(new Lava(blokTexture, new Vector2(305, 920), 80, 30));
            lava2.Add(new Lava(blokTexture, new Vector2(545, 920), 230, 30));
            lava2.Add(new Lava(blokTexture, new Vector2(965, 920), 230, 30));

            // Coins
            eggs1.Add(new Item(Content.Load<Texture2D>("Object/egg"), new Vector2(60, 700), 7, 1));
            eggs1.Add(new Item(Content.Load<Texture2D>("Object/egg"), new Vector2(740, 530), 7, 1));
            eggs1.Add(new Item(Content.Load<Texture2D>("Object/egg"), new Vector2(1820, 600), 7, 1));
            eggs1.Add(new Item(Content.Load<Texture2D>("Object/egg"), new Vector2(60, 320), 7, 1));
            eggs1.Add(new Item(Content.Load<Texture2D>("Object/egg"), new Vector2(60, 700), 7, 1));
            eggs2.Add(new Item(Content.Load<Texture2D>("Object/egg"), new Vector2(1700, 300), 7, 1));
            eggs2.Add(new Item(Content.Load<Texture2D>("Object/egg"), new Vector2(1820, 480), 7, 1));
            eggs2.Add(new Item(Content.Load<Texture2D>("Object/egg"), new Vector2(1560, 590), 7, 1));
            eggs2.Add(new Item(Content.Load<Texture2D>("Object/egg"), new Vector2(1760, 620), 7, 1));

            gate = new Item(Content.Load<Texture2D>("Object/portal"), new Vector2(30, 870), 7, 5);

            // Screens
            startScreen = new Start(startScreenBackground, dinoHead, woodenPlank, titleFont, pressEnterFont);
            levelOne = new Level(blokTexture, hero1, enemiesLevel1, lava1, eggs1, gate, tileSet1, camera, pressEnterFont);
            levelTwo = new Level(blokTexture, hero2, enemiesLevel2, lava2, eggs2, gate, tileSet2, camera, pressEnterFont);
            goal = new Goal(youWin);
            gameOver = new GameOver(youLose);
            screenManager = new ScreenManager(startScreen, levelOne, levelTwo, goal, gameOver, hero1, hero2);
        }

        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // Sprites
            blokTexture = new Texture2D(GraphicsDevice, 1, 1);
            blokTexture.SetData(new[] { Color.White });
            heroTextures.Add(Content.Load<Texture2D>("Character/Hero/Biker_run"));
            heroTextures.Add(Content.Load<Texture2D>("Character/Hero/Biker_run2"));
            heroTextures.Add(Content.Load<Texture2D>("Character/Hero/Biker_idle"));
            heroTextures.Add(Content.Load<Texture2D>("Character/Hero/Biker_jump"));
            heroTextures.Add(Content.Load<Texture2D>("Character/Hero/Biker_death"));
            walkerTextures.Add(Content.Load<Texture2D>("Character/Enemy/Walker/babydino-walk1"));
            walkerTextures.Add(Content.Load<Texture2D>("Character/Enemy/Walker/babydino-walk2"));
            jumperTextures.Add(Content.Load<Texture2D>("Character/Enemy/Jumper/fireball1"));

            startScreenBackground = Content.Load<Texture2D>("Startscreen/karina-formanova-rainforest-animation");
            dinoHead = Content.Load<Texture2D>("Startscreen/dinohead");
            woodenPlank = Content.Load<Texture2D>("Startscreen/wooden-plank");
            titleFont = Content.Load<SpriteFont>("Startscreen/title-font");
            pressEnterFont = Content.Load<SpriteFont>("Startscreen/pressenter-font");
            background1 = Content.Load<Texture2D>("FirstLevel/plx-1");
            background2 = Content.Load<Texture2D>("FirstLevel/plx-2");
            background3 = Content.Load<Texture2D>("FirstLevel/plx-3");
            background4 = Content.Load<Texture2D>("FirstLevel/plx-4");
            background5 = Content.Load<Texture2D>("FirstLevel/plx-5");
            youLose = Content.Load<Texture2D>("EndScreen/gameover");
            youWin = Content.Load<Texture2D>("EndScreen/youwin");

            //Map

            Block.Content = Content;
            tileSet1.Create(new int[,]
            {
                {2, 2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2},
{2, 2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  2,  0,  0,  2,  0,  2,  0,  0,  0,  0,  0,  2,  2},
{2, 2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  2,  0,  0,  0,  0,  2,  0,  0,  0,  0,  0,  2,  2},
{2, 2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  0,  0,  0,  0,  2,  0,  0,  0,  0,  0,  2,  2},
{2, 2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2},
{2, 2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2},
{2, 2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2},
{2, 2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2},
{2, 2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2},
{2, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2},
{2, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2},
{2, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
{2, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
{2, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  2,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
{2, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
{2, 1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  2},
{2, 2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2},
{2, 2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  2,  1,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2},
{2, 2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  2,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2},
{2, 2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  1,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2},
{2, 2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  1,  0,  0,  0,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2},
{2, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2},
{2, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2},
{2, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2},
{2, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  1,  1,  1,  1,  0,  0,  0,  0,  0,  2,  2},
{2, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  2,  2},
{2, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  2,  2},
{2, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  0,  0,  2,  2},
{2, 1,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  1,  0,  2,  2},
{2, 2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2},
{2, 2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2},
{2, 2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  2,  2,  2,  3,  3,  3,  3,  2,  2,  2,  2,  1,  1,  0,  0,  0,  1,  1,  0,  0,  0,  1,  1,  1,  1,  1,  0,  0,  0,  0,  0,  0,  1,  2,  2},
{2, 2,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  4,  4,  4,  4,  4,  2,  2,  2,  2,  2,  0,  0,  0,  2,  2,  0,  0,  0,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  1,  2,  2,  2},
{2, 2,  0,  0,  0,  0,  0,  0,  1,  1,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  4,  4,  4,  4,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  2,  2,  0,  0,  0,  2,  2,  2,  2,  2,  1,  1,  1,  1,  1,  2,  2,  2,  2},
{2, 2,  1,  1,  1,  1,  1,  1,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  4,  4,  4,  4,  2,  2,  4,  2,  2,  2,  2,  2,  2,  0,  0,  0,  2,  2,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2},
{2, 2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  4,  4,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  2,  2,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2},

            }, 30);
            tileSet2.Create(new int[,]
            {
                {2, 2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2},
{2, 2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2},
{2, 2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2},
{2, 2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  0,  0,  0,  2,  2},
{2, 2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  0,  0,  0,  2,  2},
{2, 2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  2,  2,  0,  0,  0,  2,  2},
{2, 2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  2,  2,  2,  0,  0,  0,  2,  2},
{2, 2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  0,  0,  0,  2,  2},
{2, 2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  0,  0,  0,  2,  2},
{2, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  2,  2,  3,  3,  3,  2,  2,  2,  3,  3,  3,  2,  2,  2,  3,  3,  3,  2,  2,  2,  3,  3,  3,  2,  1,  0,  0,  0,  0,  0,  0,  0,  0,  2,  0,  0,  0,  2,  2},
{2, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  4,  4,  4,  2,  2,  2,  4,  4,  4,  2,  2,  2,  4,  4,  4,  2,  2,  2,  4,  4,  4,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  2,  0,  0,  0,  2,  2},
{0, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  4,  4,  4,  2,  2,  2,  4,  4,  4,  2,  2,  2,  4,  4,  4,  2,  2,  2,  4,  4,  4,  2,  2,  2,  1,  0,  0,  0,  0,  0,  0,  2,  0,  0,  0,  2,  2},
{0, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  2,  2,  2,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  2,  2,  2,  2,  1,  0,  0,  0,  0,  0,  2,  0,  0,  0,  2,  2},
{0, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  2,  2,  2,  2,  2,  1,  0,  0,  0,  0,  2,  0,  0,  0,  2,  2},
{0, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  1,  2,  2},
{2, 1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2},
{2, 2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2},
{2, 2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  2,  2,  2,  2,  2,  2,  2},
{2, 2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2},
{2, 2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  0,  0,  0,  0,  0,  0,  2,  2},
{2, 2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  0,  0,  0,  0,  0,  0,  2,  2},
{2, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  0,  0,  0,  0,  0,  0,  2,  2},
{2, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  0,  2,  2,  2,  0,  0,  0,  0,  0,  0,  2,  2},
{2, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  1,  1,  2,  2,  2,  0,  0,  0,  0,  0,  0,  2,  2},
{2, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  1,  0,  0,  0,  0,  0,  2,  2},
{2, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  2,  2},
{2, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  2,  2},
{2, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  0,  0,  2,  2},
{2, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  1,  0,  2,  2},
{2, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2},
{2, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  2},
{2, 1,  1,  1,  1,  1,  1,  2,  2,  2,  3,  3,  3,  1,  1,  1,  1,  1,  3,  3,  3,  3,  3,  3,  3,  3,  1,  1,  1,  2,  2,  2,  3,  3,  3,  3,  3,  3,  3,  3,  2,  2,  0,  0,  0,  2,  2,  0,  0,  1,  1,  1,  1,  1,  1,  0,  0,  0,  0,  0,  0,  1,  2,  2},
{2, 2,  2,  2,  2,  2,  2,  2,  2,  2,  4,  4,  4,  2,  2,  2,  2,  2,  4,  4,  4,  4,  4,  4,  4,  4,  2,  2,  2,  2,  2,  2,  4,  4,  4,  4,  4,  4,  4,  4,  4,  2,  0,  0,  0,  2,  2,  0,  0,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  1,  2,  2,  2},
{2, 2,  2,  2,  2,  2,  2,  2,  2,  4,  4,  4,  4,  2,  2,  2,  2,  2,  4,  4,  4,  4,  4,  4,  4,  4,  2,  2,  2,  2,  2,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  2,  0,  0,  0,  2,  2,  0,  0,  2,  2,  2,  2,  2,  2,  1,  1,  1,  1,  1,  2,  2,  2,  2},
{2, 2,  2,  2,  2,  2,  2,  4,  4,  4,  4,  2,  2,  2,  2,  2,  2,  2,  4,  2,  2,  4,  4,  4,  4,  4,  2,  2,  2,  4,  4,  4,  4,  2,  2,  4,  4,  4,  4,  4,  2,  2,  0,  0,  0,  2,  2,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2},
{2, 2,  2,  2,  2,  2,  2,  2,  4,  4,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  4,  4,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  2,  2,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2},

            }, 30);

            camera = new Camera(GraphicsDevice.Viewport);
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

            if (currentState == Gamestates.Start || 
                currentState == Gamestates.Goal ||
                currentState == Gamestates.GameOver)
                _spriteBatch.Begin();
            else
                _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Transform);
            // TODO: Add your drawing code here
            _spriteBatch.Draw(background1, new Rectangle(0, 0, 1920, 1080), Color.Olive);
            _spriteBatch.Draw(background2, new Rectangle(0, 0, 1920, 1080), Color.Olive);
            _spriteBatch.Draw(background3, new Rectangle(0, 0, 1920, 1080), Color.Olive);
            _spriteBatch.Draw(background4, new Rectangle(0, 0, 1920, 1080), Color.Olive);
            _spriteBatch.Draw(background5, new Rectangle(0, 0, 1920, 1080), Color.Olive);
            screenManager.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

