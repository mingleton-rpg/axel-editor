using App;
using Renderable.Primitives;

namespace Renderable { 
    public class Canvas: IRenderable, IRenderer { 
        public Canvas(
            int width,
            int height,
            Renderer renderer
        ) { 
            Width = width;
            Height = height;
            Children = new List<IRenderable>();

            // Register this object on the renderer
            renderer.AddRenderable(this);

            // Create children
            Cursor cursor = new Cursor(
                new Coord(17,35,0), 
                renderer,
                (new Coord(1, 1, 0), new Coord(Width - 2, Height - 1, 0))
            );
            Thread thr2 = new Thread(cursor.DetectMovement);
            thr2.Start();
        }

        public int Width { get; }
        public int Height { get; }
        public List<IRenderable> Children;

        public void AddRenderable(IRenderable ren) { Children.Add(ren); }
        public void RemoveRenderable(IRenderable ren) { Children.Remove(ren); }
        public List<Axel> CompileRenderables() { 
            List<Axel> axelList = new List<Axel>();

            foreach (IRenderable ren in Children) { 
                axelList.AddRange(ren.Render());
            }
            return axelList;
        }

        public List<Axel> Render() { 
            List<Axel> axelList = new List<Axel>();

            // Show outline (will be optional)
            axelList.AddRange(new HorizontalLine(
                new Coord(0, 0, 999),
                Width,
                true,
                ConsoleColor.DarkGray
            ).Render());
            axelList.AddRange(new HorizontalLine(
                new Coord(0, Height, 999),
                Width,
                true,
                ConsoleColor.DarkGray
            ).Render());
            axelList.AddRange(new VerticalLine(
                new Coord(0, 1, 999),
                Height,
                false,
                ConsoleColor.DarkGray
            ).Render());
            axelList.AddRange(new VerticalLine(
                new Coord(Width - 1, 1, 999),
                Height,
                false,
                ConsoleColor.DarkGray
            ).Render());

            // Add Children
            axelList.AddRange(CompileRenderables());

            return axelList;
        }
    }
}