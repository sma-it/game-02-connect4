using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour.Support
{
    class Actions
    {
        Dictionary<Keys, Action> actions = new Dictionary<Keys, Action>();

        public void Set(Keys key, KeyCallback callback)
        {
            actions[key] = new Action(key, callback);
        }

        public void Remove(Keys key)
        {
            if(actions.ContainsKey(key))
            {
                actions.Remove(key);
            }
        }

        public void Update()
        {
            foreach(Action action in actions.Values)
            {
                action.Update();
            }
        }
    }
}
