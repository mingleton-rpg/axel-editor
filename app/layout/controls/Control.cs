using Engine;
using Engine.Renderable;
using Engine.Renderable.Primitives;

namespace App { 
    public class Control : Text { 
        const ConsoleColor COLOR = ConsoleColor.White;
        const string FORMAT = "[{0}]: {1}";

        public Control ( 
            Coord startPos,
            char key,
            string description,
            Renderer renderer
        ) : base ( 
            startPos,
            FORMAT,
            Text.Align.Left,
            COLOR
        ) { 
            Key = key;
            Description = description;
            renderer.AddRenderable(this);
        }

        public char Key { get; }
        public string Description { get; }

        public override List<Axel> Render() { 
            List<Axel> axelList = new List<Axel>();

            axelList.AddRange(base.Render(string.Format(
                FORMAT,
                Key.ToString(),
                Description
            )));

            return axelList;
        }
    }
}