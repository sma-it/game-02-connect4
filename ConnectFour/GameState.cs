using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ConnectFour
{
    class GameState
    {
        Support.Actions actions = new Support.Actions();
        Board board = new Board();
        Chip currentChip;
        bool player1Active = true;

        public GameState()
        {
            currentChip = new Chip(player1Active);

            actions.Set(Keys.Left, () => {
                currentChip.MoveLeft();
            });

            actions.Set(Keys.Right, () =>
            {
                currentChip.MoveRight();
            });

            actions.Set(Keys.Space, () =>
            {
                if(board.TryToMoveDown(currentChip))
                {
                    player1Active = !player1Active;
                    currentChip = new Chip(player1Active);
                }
            });
        }

        public void Update(GameTime gameTime)
        {
            actions.Update();

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
