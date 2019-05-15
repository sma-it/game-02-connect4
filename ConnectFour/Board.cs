using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    class Board
    {
        List<List<Cell>> cells = new List<List<Cell>>();

        public Board()
        {
            for(int x = 0; x < 8; x++)
            {
                cells.Add(new List<Cell>());

                for(int y = 0; y < 6; y++)
                {
                    cells[x].Add(new Cell(x, y));
                }
            }
        }

        public void Draw()
        {
            cells.ForEach(
                column => column.ForEach(
                    cell => cell.Draw()
                )
            );
        }

        public static Vector2 getScreenPos(int x, int y)
        {
            return new Vector2(-0.7f + x * 0.2f, -0.6f + y * 0.2f);
        }
    }
}
