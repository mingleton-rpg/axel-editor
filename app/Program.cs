using Engine;

namespace App { 
    class Program { 
        const int 
            WINDOW_WIDTH = 160,
            WINDOW_HEIGHT = 60,
            VIEWPORT_HEIGHT = 40;

        static void Main() { 
            // [ ENGINE ] Initialise the window
            Renderer renderer = new Renderer(WINDOW_WIDTH, WINDOW_HEIGHT, null);
            renderer.Init();

            // [ APP ] Initialise viewport
            Viewport viewport = new Viewport(WINDOW_WIDTH, VIEWPORT_HEIGHT, renderer);
            
            // Start a thread for our render input
            Thread thr1 = new Thread(renderer.RenderLoop);
            thr1.Start();
        }
    }
}