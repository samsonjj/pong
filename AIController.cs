using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PongMonogame
{
    class AIController
    {
        public List<Player> players = new List<Player>();

        public void addPlayer(Player player)
        {
            players.Add(player); 
        }

        public void Update(Ball ball)
        {
            foreach (Player player in players)
            {
                var centerY = player.Y + Player.HEIGHT / 2;
                if (centerY < ball.Y - 10)
                {
                    player.MoveDir = Player.Direction.DOWN;
                }
                else if (centerY > ball.Y + 10)
                {
                    player.MoveDir = Player.Direction.UP;
                }
                else
                {
                    player.MoveDir = Player.Direction.NONE;
                }
            }
        }
    }
}
