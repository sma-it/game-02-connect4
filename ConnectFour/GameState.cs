using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ConnectFour
{
    class GameState
    {
        Board board = new Board();
        Chip currentChip;
        bool player1Active = true;

        bool leftKeyPressed = false;
        bool rightKeyPressed = false;
        bool spaceKeyPressed = false;

        public GameState()
        {
            currentChip = new Chip(player1Active);
        }

        public void Update(GameTime gameTime)
        {
            if(!leftKeyPressed && Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                currentChip.MoveLeft();
                leftKeyPressed = true;
            }

            if(leftKeyPressed && Keyboard.GetState().IsKeyUp(Keys.Left))
            {
                leftKeyPressed = false;
            }

            if (!rightKeyPressed && Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                currentChip.MoveRight();
                rightKeyPressed = true;
            }

            if (rightKeyPressed && Keyboard.GetState().IsKeyUp(Keys.Right))
            {
                rightKeyPressed = false;
            }

            if (!spaceKeyPressed && Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                spaceKeyPressed = true;

                int column = currentChip.X;
                if (column == -1) return; // don't go down outside board

                // find free cell
                var cell = board.GetFreeCell(column);
                if (cell == null) return; // column is full
                else
                {
                    currentChip.MoveDown(cell.Y);
                    cell.Insert(currentChip);

                    player1Active = !player1Active;
                    currentChip = new Chip(player1Active);
                }
            }

            if (spaceKeyPressed && Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                spaceKeyPressed = false;
            }

            currentChip.Update(gameTime);
            board.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            currentChip.Draw();
            board.Draw();
        }
    }
}
