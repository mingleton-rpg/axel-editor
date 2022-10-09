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

            public List<Axel> Render() { 
                List<Axel> axelList = new List<Axel>();

                int offset = 0;
                if (TextAlign == Align.Right) offset = 0 - Content.Length;
                else if (TextAlign == Align.Center) offset = 0 - (Content.Length / 2);

                for (
                    int i = 0;
                    i < Content.Length;
                    i++
                ) { 
                    axelList.Add(new Axel(
                        new Coord(
                            StartPos.X + i + offset,
                            StartPos.Y,
                            StartPos.Z
                        ),
                        Content[i],
                        Color
                    ));
                }

                return axelList;
            }
        }
    }
}