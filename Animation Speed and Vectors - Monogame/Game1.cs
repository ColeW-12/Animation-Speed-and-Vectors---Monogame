using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Animation_Speed_and_Vectors___Monogame
{
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
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            greyHairRect = new Rectangle(300, 10, 100, 100);
            greyHairSpeed = new Vector2(0, 2);

            brownHairRect = new Rectangle(600, 10, 100, 100);
            brownHairSpeed = new Vector2(2, 0);



            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            greyHairtexture = Content.Load<Texture2D>("greyHair");

            brownHairTexture = Content.Load<Texture2D>("brownHair");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            greyHairRect.X += (int)greyHairSpeed.X;
            if (greyHairRect.Right >= window.Width || greyHairRect.Left <= 0)
            {
                greyHairSpeed.X *= -1;
            }
            else if (greyHairRect.Top <= 0 || greyHairRect.Bottom >= window.Height)
            {
                greyHairSpeed.Y *= -1;
            }
            greyHairRect.Y += (int)greyHairSpeed.Y;

            brownHairRect.X += (int)brownHairSpeed.X;
            if (brownHairRect.Right >= window.Width || brownHairRect.Left <= 0)
            {
                brownHairSpeed.X *= -1;
            }  
            brownHairRect.X += (int)brownHairSpeed.X;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(greyHairtexture, greyHairRect, Color.White);
            _spriteBatch.Draw(brownHairTexture, brownHairRect, Color.White);


            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
