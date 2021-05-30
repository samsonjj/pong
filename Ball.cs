using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace PongMonogame
{
    public class Ball
    {
        public float X;
        public float Y;
        public float VX;
        public float VY;
        public int Radius;
        public Texture2D Texture;

        public Ball(Texture2D texture, float x, float y, float vx, float vy, int radius)
        {
            this.Texture = texture;
            this.X = x;
            this.Y = y;
            this.VX = vx;
            this.VY = vy;
            this.Radius = radius;
        }

        public void Update()
        {
            X += VX;
            Y += VY;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)X - Radius, (int)Y - Radius, 2 * Radius, 2 * Radius), Color.White);
        }
    }
}
