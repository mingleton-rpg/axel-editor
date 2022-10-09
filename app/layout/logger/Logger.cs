using Engine;
using Engine.Renderable;
using Engine.Renderable.Primitives;

namespace App { 
    public class LoggerContainer : Canvas { 
        public LoggerContainer ( 
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

        public void InstantiateObjects() { 
            
        }
    }
}