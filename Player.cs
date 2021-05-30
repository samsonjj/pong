using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace PongMonogame
{
    public class Player
    {
        public float X;
        public float Y;

        private static float SPEED = 4.0f;
        public static int HEIGHT = 80;
        public static int WIDTH = 10;

        public Texture2D Texture;

        private bool human;

        public int Score;

        public enum Direction {
            UP,
            DOWN,
            NONE,
        }

        public Direction MoveDir { get; set; }
        public float VY
        {
            get
            {
                if (MoveDir == Direction.UP)
                {
                    return -SPEED;
                }
                else if (MoveDir == Direction.DOWN)
                {
                    return SPEED;
                }
                return 0;
            }
        }

        public Player(Texture2D texture, int x, int y, bool human)
        {
            this.Texture = texture;
            this.Texture.SetData(new[] { Color.White });

            this.X = x;
            this.Y = y;

            this.human = human;

            this.MoveDir = Direction.NONE;
        }

        public void Update()
        {
            if (human)
            {
                if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y >= .5f)
                {
                    this.MoveDir = Direction.UP;
                }
                else if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y <= -.5f)
                {
                    this.MoveDir = Direction.DOWN;
                }
                else
                {
                    this.MoveDir = Direction.NONE;
                }
            }

            this.Y += this.VY;
            this.Y = Math.Min(480.0f - HEIGHT, this.Y);
            this.Y = Math.Max(0f, this.Y);
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)X, (int)Y, WIDTH, HEIGHT), Color.White);
        }
    }
}
