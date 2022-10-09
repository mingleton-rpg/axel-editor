using Engine;
using Engine.Renderable;
using Engine.Renderable.Primitives;

namespace App { 
    public class ControlContainer : Canvas { 
        const string 
            PROMPT = "Use SHIFT + <bind>:";
        readonly (char c, string d)[] CONTROLS = {
            ('Q', "Enter ASCII character"),
            ('W', "Delete Axel"),
            ('S', "Save the current file"),
            ('X', "Cut selection"),
            ('C', "Copy selection"),
            ('V', "Paste from clipboard"),
        };

        public ControlContainer ( 
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
            // Basic message
            base.AddRenderable(new Text(
                new Coord(
                    base.StartPos.X + 2,
                    base.StartPos.Y + 2,
                    base.StartPos.Z
                ),
                PROMPT, 
                Text.Align.Left,
                ConsoleColor.DarkGray
            ));

            // Instantiate some control head-ups
            for (int i = 0; i < CONTROLS.Length; i++ ) { 
                new Control(
                    new Coord(
                        base.StartPos.X + 2, 
                        base.StartPos.Y + 3 + i, 
                        base.StartPos.Z
                        ),
                    CONTROLS[i].c,
                    CONTROLS[i].d,
                    base.Renderer
                );
            }
        }
    }
}