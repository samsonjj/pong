using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PongMonogame
{
    public class CollisionDetector
    {
        public class Response {
            public bool Over;
            public Player P;

            public Response(bool over, Player p)
            {
                this.Over = over;
                this.P = p;
            }
        }

        public static Response collide(Ball ball, Player player1, Player player2)
        {
            if (ball.X - ball.Radius <= player1.X + Player.WIDTH)
            {
                Debug.WriteLine("X: " + ball.X);
                Debug.WriteLine("Radius: " + ball.Radius);
                Debug.WriteLine("player X: " + player1.X);
                Debug.WriteLine("player w: " + Player.WIDTH);
                if (ball.Y < player1.Y || ball.Y > player1.Y + Player.HEIGHT)
                {
                    return new Response(true, player2);
                }
                else
                {
                    ball.VX *= -1;
                    var diff = ball.Y - (player1.Y + Player.HEIGHT / 2);
                    ball.VY = (float)(diff * .2) + player1.VY + ball.VY * .5f;
                }
            }
            else if (ball.X + ball.Radius >= player2.X)
            {
                if (ball.Y < player2.Y || ball.Y > player2.Y + Player.HEIGHT)
                {
                    return new Response(true, player1);
                }
                else
                {
                    ball.VX *= -1;
                    var diff = ball.Y - (player2.Y + Player.HEIGHT / 2);
                    ball.VY = (float)(diff * .2) + player2.VY + ball.VY * .5f;
                }
            }

            if (ball.Y < ball.Radius)
            {
                ball.VY *= -1;
            }
            else if (ball.Y > 480 - ball.Radius)
            {
                ball.VY *= -1;
            }

            return new Response(false, null);
        }
    }
}
