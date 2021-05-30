using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace PongMonogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D circle;

        private Ball ball;

        private Player player1;
        private Player player2;

        private AIController controller;

        private SpriteFont font;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = 720;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 480;   // set this value to the desired height of your window
            _graphics.ApplyChanges();

            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromSeconds(1 / 60.0f);  //Set the time interval to 1/30th of a second


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            circle = Content.Load<Texture2D>("circle");
            resetBall();

            Texture2D whiteRect = new Texture2D(_graphics.GraphicsDevice, 1, 1);
            whiteRect.SetData(new[] { Color.White });

            player1 = new Player(whiteRect, 10, 100, true);

            player2 = new Player(whiteRect, 700, 100, false);
            controller = new AIController();
            controller.addPlayer(player2);

            font = Content.Load<SpriteFont>("Arial");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            updateBall();

            player1.Update();
            player2.Update();
            controller.Update(ball);


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            player1.Draw(_spriteBatch, _graphics.GraphicsDevice);
            player2.Draw(_spriteBatch, _graphics.GraphicsDevice);
            ball.Draw(_spriteBatch);
            _spriteBatch.DrawString(font, player1.Score + " : " + player2.Score, new Vector2(340, 20), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void updateBall()
        {
            CollisionDetector.Response response = CollisionDetector.collide(ball, player1, player2);
            if (response.Over)
            {
                response.P.Score++;
                resetBall();
            }

            //    if (ball.X - ball.Radius<= player1.X)
            //    {
            //        // check if player2 won
            //        if (ball.Y < player1.Y || ball.Y > player1.Y + Player.HEIGHT)
            //        {
            //            score1 += 1;
            //            resetBall();
            //        }
            //        else
            //        {
            //            ball.VX *= -1;
            //            var diff = ball.Y - (player1.Y + Player.HEIGHT / 2);
            //            ball.VY = (float)(diff * .3);
            //        }
            //    }
            //    else if (ball.X + ball.Radius >= player2.X)
            //    {
            //        if (ball.Y < player2.Y || ball.Y > player2.Y + Player.HEIGHT)
            //        {
            //            score2 += 1;
            //            resetBall();
            //        }
            //        else
            //        {
            //            ball.VX *= -1;
            //            var diff = ball.Y - (player2.Y + Player.HEIGHT / 2);
            //            ball.VY = (float)(diff * .3);
            //            Debug.WriteLine(player2.Y + " " + Player.HEIGHT + " " + ball.Y + " " + diff + " " + ball.VY);
            //        }
            //    }

            //    if (ball.Y < ball.Radius)
            //    {
            //        ball.VY *= -1;
            //    }
            //    else if (ball.Y > 480 - ball.Radius)
            //    {
            //        ball.VY *= -1;
            //    }

            //    ball.X += ball.VX;
            //    ball.Y += ball.VY;
            ball.Update();
        }

        private void resetBall()
        {
            ball = new Ball(circle, 400, 240, 5, 0, 8);
        }
    }
}
