using Renderable;

namespace App { 
    public class Renderer { 
        const char BLANK = ' ';

        public Renderer(
            int width,
            int height,
            List<IRenderable> renderQueue
        ) { 
            Width = width;
            Height = height - 3;

            RenderQueue = renderQueue;
            if (RenderQueue is null) RenderQueue = new List<IRenderable>();
        }

        public int Width { get; }
        public int Height { get; }

        public List<IRenderable> RenderQueue { get; }

        public void Init() { 
            Console.SetWindowSize(Width, Height + 3);
            Console.Clear();
            Console.CursorVisible = false;
        }

        public void RenderLoop() { 
            while(true) {
                InstantRender();
                Thread.Sleep(20);
            }
        }

        public void AddRenderable(IRenderable ren) { 
            RenderQueue.Add(ren);
        }

        public void RemoveRenderable(IRenderable ren) { 
            RenderQueue.Remove(ren);
        }

        private List<Axel> CompileRenderables() { 
            List<Axel> axelList = new List<Axel>();

            foreach (IRenderable ren in RenderQueue) { 
                axelList.AddRange(ren.Render());
            }
            return axelList;
        }

        private void ColorRender() { 
            // Compile all renderables
            List<Axel> axelQueue = CompileRenderables();

            // Sorts the list from 0,0 to WINDOW_WIDTH, WINDOW_HEIGHT, ready for rendering
            axelQueue.Sort();      

            Console.SetCursorPosition(0, 0);
            for (int r = 0; r < Height; r++) {          // Rows
                for (int c = 0; c < Width; c++) {       // Columns
                    // Find the first Axel for this position
                    Axel axel = axelQueue.Find(a => (a.Pos.X == c && a.Pos.Y == r));

                    // Render it, or a blank character if we can't find it
                    if (axel is not null) {
                        Console.ForegroundColor = axel.Color;
                        Console.Write(axel.C);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else Console.Write(BLANK);
                }
                // Console.WriteLine();
            }
        }

        // Renders instantaneously, but loses colors
        private void InstantRender() { 
            // Compile all renderables
            List<Axel> axelQueue = CompileRenderables();

            // Sorts the list from 0,0 to WINDOW_WIDTH, WINDOW_HEIGHT, ready for rendering
            axelQueue.Sort();      

            string renderString = "\r";

            Console.SetCursorPosition(0, 0);
            for (int r = 0; r < Height; r++) {          // Rows
                for (int c = 0; c < Width; c++) {       // Columns
                    // Find the first Axel for this position
                    Axel axel = axelQueue.Find(a => (a.Pos.X == c && a.Pos.Y == r));

                    // Render it, or a blank character if we can't find it
                    if (axel is not null) renderString = renderString + axel.C.ToString();
                    else renderString = renderString + BLANK.ToString();
                }
            }
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(renderString);
        }
    }
}