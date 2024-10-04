using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    /// <summary>
    /// This is where the application begins.
    /// </summary>
    public class EntryPoint
    {
        /// <param name="args"></param>
        [STAThread]
        static void Main(string[] args)
        {
            GameEngine instance = GameEngine.GetInstance();

            if (instance == null)
                return;

            new Game(); //XYZ implements AbstractGame and subscribes himself to the game engine

            instance.Run();

            //Clean up unmanaged resources
            instance.Dispose();
        }
    }
}
