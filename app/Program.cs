using Engine;
using Engine.Renderable.Primitives;

namespace App { 
    class Program { 
        const int 
            WINDOW_WIDTH = 160,
            WINDOW_HEIGHT = 60;

        static void Main() { 
            // [ ENGINE ] Initialise the window
            Renderer renderer = new Renderer(WINDOW_WIDTH, WINDOW_HEIGHT, null);
            renderer.Init();

            // [ APP ] Initialise viewport
            Viewport viewport = new Viewport(
                new Coord(0, 0, 999),
                WINDOW_WIDTH, 
                2 * (WINDOW_HEIGHT / 3),
                renderer
            );
            ControlContainer controls = new ControlContainer(
                new Coord(
                    0,
                    (2 * (WINDOW_HEIGHT / 3)) + 1,
                    999
                ),
                WINDOW_WIDTH / 3, 
                (WINDOW_HEIGHT / 3) - 5,
                renderer
            );
            LoggerContainer logger = new LoggerContainer(
                new Coord(
                    (WINDOW_WIDTH / 3) + 1, 
                    (2 * (WINDOW_HEIGHT / 3)) + 1,
                    999
                ),
                (2 * (WINDOW_WIDTH / 3)), 
                (WINDOW_HEIGHT / 3) - 5,
                renderer
            );
            
            // Start a thread for our render input
            Thread thr1 = new Thread(renderer.RenderLoop);
            thr1.Start();
        }
    }
}