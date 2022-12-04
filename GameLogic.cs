using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSServer
{
    internal class GameLogic
    {
        public static void Update()
        {
            ThreadManager.UpdateMain();
        }
    }
}
