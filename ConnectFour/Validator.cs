using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    public enum Winner
    {
        None,
        Player1,
        Player2,
    }

    class Validator
    {
        Board board;

        public Validator(Board board)
        {
            this.board = board;
        }

        public Winner FindWinner()
        {
            for (int x = 0; x < board.Width - 3; x++)
            {
                for (int y = 0; y < board.Height; y++)
                {
                    var winner = HorizontalMatch(x, y);
                    if (winner != Winner.None) return winner;
                }
            }

            for (int x = 0; x < board.Width; x++)
            {
                for (int y = 0; y < board.Height - 3; y++)
                {
                    var winner = VerticalMatch(x, y);
                    if (winner != Winner.None) return winner;
                }
            }

            for (int x = 0; x < board.Width - 3; x++)
            {
                for (int y = 0; y < board.Height - 3; y++)
                {
                    var winner = DiagonalUpMatch(x, y);
                    if (winner != Winner.None) return winner;
                }
            }

            for (int x = 0; x < board.Width - 3; x++)
            {
                for (int y = 3; y < board.Height; y++)
                {
                    var winner = DiagonalDownMatch(x, y);
                    if (winner != Winner.None) return winner;
                }
            }

            return Winner.None;
        }

        private Winner VerticalMatch(int x, int y)
        {
            CellState state = board.Cells[x][y].State();
            if (state == CellState.Empty) return Winner.None;
            for (int i = y; i < y + 4; i++)
            {
                CellState neighbour = board.Cells[x][i].State();
                if (neighbour == CellState.Empty) return Winner.None;
                if (neighbour != state) return Winner.None;
            }
            return state == CellState.PlayerOne ? Winner.Player1 : Winner.Player2;
        }

        private Winner HorizontalMatch(int x, int y)
        {
            CellState state = board.Cells[x][y].State();
            if (state == CellState.Empty) return Winner.None;
            for (int i = x; i < x + 4; i++)
            {
                CellState neighbour = board.Cells[i][y].State();
                if (neighbour == CellState.Empty) return Winner.None;
                if (neighbour != state) return Winner.None;
            }
            return state == CellState.PlayerOne ? Winner.Player1 : Winner.Player2;
        }

        private Winner DiagonalUpMatch(int x, int y)
        {
            CellState state = board.Cells[x][y].State();
            if (state == CellState.Empty) return Winner.None;
            for (int i = 0; i < 3; i++)
            {
                x++; y++;
                CellState neighbour = board.Cells[x][y].State();
                if (neighbour == CellState.Empty) return Winner.None;
                if (neighbour != state) return Winner.None;
            }
            return state == CellState.PlayerOne ? Winner.Player1 : Winner.Player2;
        }

        private Winner DiagonalDownMatch(int x, int y)
        {
            CellState state = board.Cells[x][y].State();
            if (state == CellState.Empty) return Winner.None;
            for (int i = 0; i < 3; i++)
            {
                x--; y++;
                CellState neighbour = board.Cells[x][y].State();
                if (neighbour == CellState.Empty) return Winner.None;
                if (neighbour != state) return Winner.None;
            }
            return state == CellState.PlayerOne ? Winner.Player1 : Winner.Player2;
        }
    }
}
