using Engine;
using Engine.Renderable;
using Engine.Renderable.Primitives;
using App.Renderable;

namespace App { 
    public class Viewport : Canvas {

        public Viewport ( 
            Coord startPos,
            int width,
            int height,
            Renderer renderer
        ) : base ( 
            startPos,
            width,
            height, 
            renderer
        ) { 
            InstantiateObjects();
        }

        private void InstantiateObjects() { 
            // Create children
            Cursor cursor = new Cursor(
                new Coord(Width / 2, Height / 2, 0), 
                base.Renderer,
                (new Coord(1, 1, 0), new Coord(Width - 2, Height - 1, 0))
            );
            Thread thr2 = new Thread(cursor.DetectMovement);
            thr2.Start();
        }
    }
}