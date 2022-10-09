using Engine;
using Engine.Renderable;
using Engine.Renderable.Primitives;

namespace App { 
    public class LogRow : Text {
        const ConsoleColor COLOR = ConsoleColor.White;
        const string FORMAT = "{1}";

        public LogRow(
            Coord startPos,
            string content,
            Renderer renderer
        ) : base (
            startPos,
            FORMAT,
            Text.Align.Left,
            COLOR
        ) { 
            Content = content;
        }

        public new string Content { get; }
        public int Row; 

        public override List<Axel> Render() { 
            List<Axel> axelList = new List<Axel>();

            axelList.AddRange(base.Render(string.Format(
                FORMAT,
                Content
            )));

            return axelList;
        }
    }
}