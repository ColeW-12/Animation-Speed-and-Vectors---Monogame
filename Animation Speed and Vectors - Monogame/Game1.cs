using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Animation_Speed_and_Vectors___Monogame
{   
    enum Screen
    {
        Intro,
        TribbleYard, 
        End
    }
   
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        Texture2D greyHairtexture;
        Rectangle greyHairRect;
        Vector2 greyHairSpeed;

        Texture2D brownHairTexture;
        Rectangle brownHairRect;
        Vector2 brownHairSpeed;

        Texture2D blondHairTexture;
        Rectangle blondHairRect;
        Vector2 blondHairSpeed;

        Texture2D orangeHairTexture;
        Rectangle orangeHairRect;
        Vector2 orangeHairSpeed;

        Texture2D TribbleIntroTexture;

        Texture2D TribbleOutroTexture;

        Screen screen;


        MouseState mouseState;

        Color greyTribbleColorMask;

        Color orangeTribbleColorMask;

        Random generator;
        int colour;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0, 0, 800, 600);

            screen = Screen.Intro;

            
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            greyHairRect = new Rectangle(300, 10, 100, 100);
            greyHairSpeed = new Vector2(3, 2);

            brownHairRect = new Rectangle(600, 10, 100, 100);
            brownHairSpeed = new Vector2(2, 0);

            blondHairRect = new Rectangle(200, 200, 100, 100);
            blondHairSpeed = new Vector2(0, 2);

            orangeHairRect = new Rectangle(400, 200, 100, 100);
            orangeHairSpeed = new Vector2(4, 5);

            greyTribbleColorMask = Color.White;

            

            orangeTribbleColorMask = Color.White;

            generator = new Random();

            
            colour = generator.Next(1, 3);
            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            

            greyHairtexture = Content.Load<Texture2D>("greyHair");

            brownHairTexture = Content.Load<Texture2D>("brownHair");

            blondHairTexture = Content.Load<Texture2D>("blondHair");

            orangeHairTexture = Content.Load<Texture2D>("orangeHair");

            TribbleIntroTexture = Content.Load<Texture2D>("tribble_intro");

            TribbleOutroTexture = Content.Load<Texture2D>("gameOver");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.TribbleYard;
            }
            else if (screen == Screen.TribbleYard)
            {
                greyHairRect.X += (int)greyHairSpeed.X;
                if (greyHairRect.Right >= window.Width || greyHairRect.Left <= 0)
                {
                    greyHairSpeed.X *= -1;
                    greyTribbleColorMask = Color.Green;
                }

                greyHairRect.Y += (int)greyHairSpeed.Y;

                if (greyHairRect.Top <= 0 || greyHairRect.Bottom >= window.Height)
                {
                    greyHairSpeed.Y *= -1;
                    greyTribbleColorMask = Color.HotPink;
                }

                brownHairRect.X += (int)brownHairSpeed.X;
                if (brownHairRect.Right >= 900 || brownHairRect.Left <= 0)
                {
                    brownHairSpeed.X *= 1;
                    brownHairRect = new Rectangle(0, 100, 100, 100);
                }

                brownHairRect.Y += (int)brownHairSpeed.Y;

                if (brownHairRect.Top <= 0 || brownHairRect.Left <= window.Height)
                {
                    brownHairSpeed.Y *= -2;
                }


                blondHairRect.X += (int)blondHairSpeed.X;
                if (blondHairRect.Right >= window.Width || blondHairRect.Left <= 0)
                {
                    blondHairSpeed.X *= -1;
                }

                blondHairRect.Y += (int)blondHairSpeed.Y;

                if (blondHairRect.Top <= 0 || blondHairRect.Bottom >= window.Height)
                {
                    blondHairSpeed.Y *= -1;
                }


                orangeHairRect.X += (int)orangeHairSpeed.X;

                if (orangeHairRect.Right >= window.Width || orangeHairRect.Left <= 0)
                {

                    orangeHairSpeed.X *= -1;
                    colour = generator.Next(2);
                    if (colour == 0)
                        orangeTribbleColorMask = Color.Purple;
                    else
                        orangeTribbleColorMask = Color.Green;

                }
                orangeHairRect.Y += (int)orangeHairSpeed.Y;

                if (orangeHairRect.Top <= 0 || orangeHairRect.Bottom >= window.Height)
                {
                    orangeHairSpeed.Y *= -1;
                    if (colour == 0)
                        orangeTribbleColorMask = Color.AliceBlue;
                    else
                        orangeTribbleColorMask = Color.Yellow;
                }

                if (mouseState.RightButton == ButtonState.Pressed)
                    screen = Screen.End;
            }
            else if (screen == Screen.End)
            {

            }
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(TribbleIntroTexture, window, Color.White);
            }
            else if (screen == Screen.TribbleYard)
            {
                _spriteBatch.Draw(greyHairtexture, greyHairRect, greyTribbleColorMask);
                _spriteBatch.Draw(brownHairTexture, brownHairRect, Color.White);
                _spriteBatch.Draw(blondHairTexture, blondHairRect, Color.White);
                _spriteBatch.Draw(orangeHairTexture, orangeHairRect, orangeTribbleColorMask);
            }
            if (screen == Screen.End)
            {
                _spriteBatch.Draw(TribbleOutroTexture, window, Color.White);
            }
            
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
