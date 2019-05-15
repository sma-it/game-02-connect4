using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    enum KeyState
    {
        None,
        InGame,
        GameOver,
    }

    class GameController
    {
        Board board;
        Chip currentChip;

        KeyState currentKeyState = KeyState.None;
        KeyState desiredKeyState;

        Support.Actions actions = new Support.Actions();
        Validator validator;

        public bool NewChipNeeded { get; set; } = false;

        public Winner Winner { get; set; } = Winner.None;

        public GameController(Board board)
        {
            this.board = board;
            validator = new Validator(board);
            desiredKeyState = KeyState.InGame;
            verifyKeyState();
        }

        public void Update(Chip currentChip)
        {
            this.currentChip = currentChip;
            actions.Update();
            verifyKeyState();
        }

        void verifyKeyState()
        {
            if (desiredKeyState == currentKeyState) return;
            if (desiredKeyState == KeyState.InGame) setGameKeyState();
            else setGameOverKeyState();
        }

        void setGameKeyState()
        {
            actions.Remove(Keys.N);

            actions.Set(Keys.Left, () => {
                currentChip.MoveLeft();
            });

            actions.Set(Keys.Right, () =>
            {
                currentChip.MoveRight();
            });

            actions.Set(Keys.Space, () =>
            {
                if (board.TryToMoveDown(currentChip))
                {
                    Winner winner = validator.FindWinner();
                    if (winner == Winner.None)
                    {
                        NewChipNeeded = true;   
                    } else
                    {
                        this.Winner = winner;
                        desiredKeyState = KeyState.GameOver;
                    }
                }
            });

            currentKeyState = KeyState.InGame;
        }

        void setGameOverKeyState()
        {
            actions.Remove(Keys.Left);
            actions.Remove(Keys.Right);
            actions.Remove(Keys.Space);

            actions.Set(Keys.N, () =>
            {
                // starts a new game
                board.Clear();
                Winner = Winner.None;
                NewChipNeeded = true;
                desiredKeyState = KeyState.InGame;
            });
            currentKeyState = KeyState.GameOver;
        }
    }
}
