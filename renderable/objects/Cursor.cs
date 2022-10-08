using App;
using Renderable.Primitives;

namespace Renderable { 
    public class Cursor : IRenderable { 
        const char CURSOR_CHAR = '+';
        const int CURSOR_FLASH = 10;

        public Cursor ( 
            Coord startPoint,
            Renderer renderer,
            (Coord min, Coord max) moveArea
        ) { 
            Pos = startPoint;
            MoveArea = (moveArea.min, moveArea.max);
            isFlashing = 0;

            // Register this object on the renderer
            renderer.AddRenderable(this);
        }

        private Coord Pos;
        private (Coord min, Coord max) MoveArea { get; }
        private int isFlashing;

        public void Move(Coord dPos) { 
            Pos = new Coord(
                Pos.X + dPos.X,
                Pos.Y + dPos.Y,
                Pos.Z + dPos.Z
            );
        }

        public void DetectMovement() { 
            while(true) {
                // Simple movement mechanics
                if (Console.KeyAvailable) { 
                    int dX = 0;
                    int dY = 0;

                    switch (Console.ReadKey(false).Key) { 
                        case ConsoleKey.LeftArrow: dX = -1; break;
                        case ConsoleKey.RightArrow: dX = 1; break;
                        case ConsoleKey.UpArrow: dY = -1; break;
                        case ConsoleKey.DownArrow: dY = 1; break;
                    }

                    if (Pos.X + dX < MoveArea.min.X || Pos.X + dX > MoveArea.max.X) dX = 0;
                    if (Pos.Y + dY < MoveArea.min.Y || Pos.Y + dY > MoveArea.max.Y) dY = 0;
                    
                    Move(new Coord(dX, dY, 0));
                }
            }
        }

        public List<Axel> Render() { 
            List<Axel> axelList = new List<Axel>();

            if (isFlashing > CURSOR_FLASH / 2) {
                axelList.Add(new Axel(
                    Pos,
                    CURSOR_CHAR,
                    ConsoleColor.DarkBlue
                ));
            }
            if (isFlashing == CURSOR_FLASH) isFlashing = 0;
            isFlashing += 1;


            return axelList;
        }
    }
}