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

        Chip chip = null;

        public Cell(int x, int y) : base("board_cell", new Vector2(), new Vector2(0.2f))
        {
            X = x;
            Y = y;

            Position = Board.getScreenPos(x, y);
        }

        public bool HasChip()
        {
            return chip != null;
        }

        public void Insert(Chip chip)
        {
            this.chip = chip;
        }

        public void Update(GameTime gameTime)
        {
            if (chip != null) chip.Update(gameTime);
        }

        public new void Draw()
        {
            if (chip != null) chip.Draw();
            base.Draw();
        }
    }
}
