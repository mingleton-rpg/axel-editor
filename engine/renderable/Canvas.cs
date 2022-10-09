using Engine.Renderable.Primitives;

namespace Engine { 
    namespace Renderable { 
        public class Canvas: IRenderable, IRenderer { 
            public Canvas(
                Coord startPos,
                int width,
                int height,
                Renderer renderer
            ) { 
                StartPos = startPos;
                Width = width;
                Height = height;
                Renderer = renderer;
                Children = new List<IRenderable>();

                // Register this object on the renderer
                renderer.AddRenderable(this);
            }

            public Coord StartPos { get; }
            public int Width { get; }
            public int Height { get; }
            public List<IRenderable> Children;
            public Renderer Renderer { get; }

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
                    new Coord(StartPos.X, StartPos.Y, StartPos.Z),
                    Width,
                    true,
                    ConsoleColor.DarkGray
                ).Render());
                axelList.AddRange(new HorizontalLine(
                    new Coord(StartPos.X, StartPos.Y + Height, StartPos.Z),
                    Width,
                    true,
                    ConsoleColor.DarkGray
                ).Render());
                axelList.AddRange(new VerticalLine(
                    new Coord(StartPos.X, StartPos.Y + 1, StartPos.Z),
                    Height,
                    false,
                    ConsoleColor.DarkGray
                ).Render());
                axelList.AddRange(new VerticalLine(
                    new Coord(StartPos.X + Width - 1, StartPos.Y + 1, StartPos.Z),
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
}