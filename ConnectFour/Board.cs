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
        int width = 8;
        int height = 6;

        public Board()
        {
            for(int x = 0; x < width; x++)
            {
                cells.Add(new List<Cell>());

                for(int y = 0; y < height; y++)
                {
                    cells[x].Add(new Cell(x, y));
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            cells.ForEach(
                column => column.ForEach(
                    cell => cell.Update(gameTime)
                )
            );
        }

        public void Draw()
        {
            cells.ForEach(
                column => column.ForEach(
                    cell => cell.Draw()
                )
            );
        }

        public Cell GetFreeCell(int column)
        {
            for(int i = 0; i < height; i++)
            {
                if (!cells[column][i].HasChip()) return cells[column][i];
            }
            // no free cell found!
            return null;
        }

        public static Vector2 getScreenPos(int x, int y)
        {
            return new Vector2(-0.7f + x * 0.2f, -0.6f + y * 0.2f);
        }
    }
}
