using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ConnectFour
{
    class GameState
    {
        Support.Actions actions = new Support.Actions();
        Board board = new Board();
        Validator validator;
        Chip currentChip;
        bool player1Active = true;

        string statusText = string.Empty;

        public GameState()
        {
            currentChip = new Chip(player1Active);
            validator = new Validator(board);

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
                    Winner winner = validator.FindWinner();
                    if(winner == Winner.None)
                    {
                        player1Active = !player1Active;
                        currentChip = new Chip(player1Active);
                    } else
                    {
                        statusText = winner.ToString();
                    }
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

            Support.Font.PrintStatusLine(statusText, 0, Color.Black);
        }
    }
}
