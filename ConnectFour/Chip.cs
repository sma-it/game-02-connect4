using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ConnectFour
{
    enum Move
    {
        Left,
        Right,
        Down,
        None,
    }

    public class Chip : Support.Texture
    {
        public int X = -1;
        public int Y = 6;

        Vector2 targetPosition;
        Move move = Move.None;

        bool player1;
        public bool Player1 { get => player1; }

        public Chip(bool player1) : base(player1 ? "red_chip" : "yellow_chip", new Vector2(), new Vector2(0.2f))
        {
            Position = Board.getScreenPos(X, Y);
            targetPosition = Position;
            this.player1 = player1;
        }

        public void MoveLeft()
        {
            if(move != Move.Down && X > 0)
            {
                X--;
                move = Move.Left;
                targetPosition = Board.getScreenPos(X, Y);
            }
        }

        public void MoveRight()
        {
            if (move != Move.Down && X < 7)
            {
                X++;
                move = Move.Right;
                targetPosition = Board.getScreenPos(X, Y);
            }
        }

        public void MoveDown(int target)
        {
            Y = target;
            move = Move.Down;
            targetPosition = Board.getScreenPos(X, Y);
            Position.X = targetPosition.X;
        }

        public void Update(GameTime gameTime)
        {
            switch(move)
            {
                case Move.Left:
                    {
                        Position.X -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                        if (Position.X <= targetPosition.X)
                        {
                            move = Move.None;
                        }
                        break;
                    }

                case Move.Right:
                    {
                        Position.X += (float)gameTime.ElapsedGameTime.TotalSeconds;
                        if (Position.X >= targetPosition.X)
                        {
                            move = Move.None;
                        }
                        break;
                    }

                case Move.Down:
                    {
                        Position.Y -= (float)gameTime.ElapsedGameTime.TotalSeconds * 4;
                        if(Position.Y <= targetPosition.Y)
                        {
                            move = Move.None;
                        }
                        break;
                    }

                case Move.None:
                    Position = targetPosition;
                    break;
            }
        }

        
    }
}
