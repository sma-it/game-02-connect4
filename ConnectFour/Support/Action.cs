using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour.Support
{
    public delegate void KeyCallback();

    public class Action
    {
        Keys key;
        KeyCallback func;
        bool isPressed = false;

        public Action(Keys key, KeyCallback func)
        {
            this.key = key;
            this.func = func;
        }

        public void Update()
        {
            if(!isPressed && Keyboard.GetState().IsKeyDown(key))
            {
                func();
                isPressed = true;
            }
            if(isPressed && Keyboard.GetState().IsKeyUp(key))
            {
                isPressed = false;
            }
        }
    }
}
