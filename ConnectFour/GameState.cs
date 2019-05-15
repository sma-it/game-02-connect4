using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ConnectFour
{
    class GameState
    {
        Board board = new Board();

        public GameState()
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime)
        {
            board.Draw();
        }
    }
}
