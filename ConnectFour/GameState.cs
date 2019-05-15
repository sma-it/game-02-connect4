using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ConnectFour
{
    class GameState
    {
        Board board = new Board();
        GameController controller;
        Chip currentChip;
        bool player1Active = true;

        string statusText = string.Empty;

        public GameState()
        {
            currentChip = new Chip(player1Active);
            controller = new GameController(board);
        }

        public void Update(GameTime gameTime)
        {
            controller.Update(currentChip);

            if (controller.NewChipNeeded)
            {
                player1Active = !player1Active;
                currentChip = new Chip(player1Active);
                controller.NewChipNeeded = false;
            }

            currentChip.Update(gameTime);
            board.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            if(controller.Winner == Winner.None)
            {
                currentChip.Draw();
                board.Draw();
            }
            else if (controller.Winner == Winner.Player1)
            {
                Support.Font.PrintAt(new Vector2(-0.4f, 0), "Player 1 has won this round.", Color.White);
                Support.Font.PrintAt(new Vector2(-0.37f, -0.2f), "Press N for another game.", Color.White);
            } else
            {
                Support.Font.PrintAt(new Vector2(-0.4f, 0), "Player 2 has won this round.", Color.White);
                Support.Font.PrintAt(new Vector2(-0.37f, -0.2f), "Press N for another game.", Color.White);
            }
        }
    }
}
