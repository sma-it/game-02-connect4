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
                currentChip.MoveDown(0);
                spaceKeyPressed = true;
            }

            if (spaceKeyPressed && Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                spaceKeyPressed = false;
            }

            currentChip.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            currentChip.Draw();
            board.Draw();
        }
    }
}
