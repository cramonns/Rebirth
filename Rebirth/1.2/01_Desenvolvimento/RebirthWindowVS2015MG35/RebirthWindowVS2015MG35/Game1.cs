using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Windows.Forms;

namespace Rebirth
{
    /// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        GameScreen[] screens;

        public enum ScreenID
        {
            intro,
            menu,
            world
        }

        public static ScreenID currentScreen;

#if EDITOR
        Control gameForm;
        IntPtr drawingSurface;
        Form parentForm;
        PictureBox pictureBox;
        bool editor = false;
 
        public static bool editorMode;

        private void graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e){
            // Finally attach game1's draw ability to the picture box in winforms.
            e.GraphicsDeviceInformation.PresentationParameters.DeviceWindowHandle = drawingSurface;
        }

        public Game1(IntPtr drawingSurface, Form parentForm, System.Windows.Forms.PictureBox pictureBox){
            Content.RootDirectory = "Content";	            
            screens = new GameScreen[Enum.GetNames(typeof(ScreenID)).Length];

            this.drawingSurface = drawingSurface;
            this.parentForm = parentForm;
            this.pictureBox = pictureBox;

            GameManager.initialize(this);
            DisplayManager.initialize(pictureBox.Width, pictureBox.Height);

            // prepare graphics event
            graphics.PreparingDeviceSettings +=
                new EventHandler<PreparingDeviceSettingsEventArgs>(graphics_PreparingDeviceSettings);

            gameForm = System.Windows.Forms.Control.FromHandle(this.Window.Handle);
            gameForm.Visible = false;
            gameForm.VisibleChanged += new System.EventHandler(gameForm_VisiblilityChanged);

            //Tell the mouse it will be getting it's input through the pictureBox
            Mouse.WindowHandle = drawingSurface;

            editor = true;
            
            currentScreen = ScreenID.world;

        }

        private void gameForm_VisiblilityChanged(object sender, EventArgs e){
            if (gameForm.Visible == true)
                gameForm.Visible = false;
        }
#endif

        public Game1()
        {
            //this.Content = new Microsoft.Xna.Framework.Content.ContentManager(null, "Content");
            Content.RootDirectory = "Content";
            GameManager.initialize(this);
            DisplayManager.initialize();
            screens = new GameScreen[Enum.GetNames(typeof(ScreenID)).Length];
            currentScreen = ScreenID.intro;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
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

            //create the content managers
            TextureManager.initialize(Content);
            //VideoManager.initialize(Content);

            //create all screens
            screens[(int)ScreenID.intro] = new IntroScreen(spriteBatch);
            screens[(int)ScreenID.menu] = new MenuScreen(spriteBatch);
            screens[(int)ScreenID.world] = new GameWorld(spriteBatch);

            //load all screens
            int totalScreens = Enum.GetNames(typeof(ScreenID)).Length;
            for (int i = 0; i < totalScreens; i++)
                screens[i].LoadScreen();

            //load textures
            TextureManager.load(TextureManager.TextureID.white);
            TextureManager.load(TextureManager.TextureID.black);

#if EDITOR
            if (editor) {
                (screens[(int)ScreenID.world] as GameWorld).editMode();
                //(parentForm as LevelEditor).startEditor();
            }
            else               
#endif
            LoadManager.LoadContainerManager();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            ControllerManager.Update(gameTime);
            if (ControllerManager.TriggerSunglasses)
            {
                GameManager.globalVariables.sunglassesOn = !GameManager.globalVariables.sunglassesOn;
            }
            screens[(int)currentScreen].Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Color bgColor = Color.CornflowerBlue;
#if EDITOR
            if (!editor){
#endif
            if (currentScreen == ScreenID.world)
            {
                switch (GameManager.globalVariables.currentSeason)
                {
                    case Enumerations.Seasons.Winter:
                        if (GameManager.globalVariables.sunglassesOn)
                        {
                            bgColor = Color.DarkOrange;
                        }
                        else bgColor = Color.White;
                        break;
                    case Enumerations.Seasons.Spring:
                        if (GameManager.globalVariables.sunglassesOn)
                        {
                            bgColor = Color.DarkGoldenrod;
                        }
                        else bgColor = Color.DeepSkyBlue;
                        break;
                    case Enumerations.Seasons.Summer:
                        if (GameManager.globalVariables.sunglassesOn)
                        {
                            bgColor = Color.White;
                        }
                        else bgColor = Color.DarkOrange;
                        break;
                    case Enumerations.Seasons.Autumn:
                        if (GameManager.globalVariables.sunglassesOn)
                        {
                            bgColor = Color.DeepSkyBlue;
                        }
                        else bgColor = Color.DarkGoldenrod;
                        break;
                }
            }
#if EDITOR
            }
#endif
            graphics.GraphicsDevice.Clear(bgColor);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

            screens[(int)currentScreen].Draw(gameTime);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public GameWorld getWorld()
        {
            return screens[(int)ScreenID.world] as GameWorld;
        }

        public void loadCurrentScreen()
        {
            screens[(int)currentScreen].LoadScreen();
        }

    }
}
