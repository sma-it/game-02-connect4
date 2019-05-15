using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ConnectFour
{
    public class Cell : Support.Texture
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Cell(int x, int y) : base("board_cell", new Vector2(), new Vector2(0.2f))
        {
            X = x;
            Y = y;

            Position = Board.getScreenPos(x, y);
        }
    }
}
