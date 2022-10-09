using Engine.Renderable.Primitives;

namespace Engine { 
    namespace Renderable { 
        public class Text : IRenderable { 
            public enum Align { 
                Left,
                Right,
                Center
            };

            public Text ( 
                Coord startPos,
                string content,
                Align textAlign, 
                ConsoleColor color
            ) { 
                StartPos = startPos;
                Content = content;
                TextAlign = textAlign;
                Color = color;
            }

            public Coord StartPos { get; }
            public string Content { get; }
            public Align TextAlign { get; }
            public ConsoleColor Color { get; }

            public virtual List<Axel> Render() { 
                return Render(Content);
            }

            public virtual List<Axel> Render(string text) { 
                List<Axel> axelList = new List<Axel>();

                int offset = 0;
                if (TextAlign == Align.Right) offset = 0 - text.Length;
                else if (TextAlign == Align.Center) offset = 0 - (text.Length / 2);

                for (
                    int i = 0;
                    i < text.Length;
                    i++
                ) { 
                    axelList.Add(new Axel(
                        new Coord(
                            StartPos.X + i + offset,
                            StartPos.Y,
                            StartPos.Z
                        ),
                        text[i],
                        Color
                    ));
                }

                return axelList;
            }
        }
    }
}