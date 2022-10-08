using Renderable.Primitives;

namespace Renderable { 
    public class Line : IRenderable { 
        public const char
            H_LINE = '-',
            V_LINE = '|',
            CORNER = '+';

        public Line (
            Coord startPos,
            int length,
            bool withCorners,
            ConsoleColor color
        ) { 
            StartPos = startPos;
            Length = length;
            WithCorners = withCorners;
            Color = color;
        }

        public Coord StartPos { get; }
        public int Length { get; }
        public bool WithCorners { get; }
        public ConsoleColor Color { get; }

        public virtual List<Axel> Render() { 
            return new List<Axel>();
        }
    }

    public class HorizontalLine : Line, IRenderable {
        public HorizontalLine (
            Coord startPos,
            int length,
            bool withCorners,
            ConsoleColor color
        ) : base ( 
            startPos,
            length,
            withCorners,
            color
        ) { }

        public override List<Axel> Render() { 
            List<Axel> axelList = new List<Axel>();

            if (base.WithCorners) axelList.Add(new Axel(
                base.StartPos,
                CORNER, 
                base.Color
            ));
            
            for (
                int i = (base.WithCorners ? 1 : 0);
                i < (base.WithCorners ? base.Length - 1 : base.Length);
                i++
            ) { 
                axelList.Add(new Axel(
                    new Coord(
                        base.WithCorners ? base.StartPos.X + i : base.StartPos.X + i,
                        base.StartPos.Y,
                        base.StartPos.Z
                    ),
                    H_LINE,
                    base.Color
                ));
            }

            if (base.WithCorners) axelList.Add(new Axel(
                new Coord(
                    (base.StartPos.X + base.Length) - 1, 
                    base.StartPos.Y, 
                    base.StartPos.Z
                ),
                CORNER,
                base.Color
            ));

            return axelList;
        }
    }

    public class VerticalLine : Line, IRenderable {
        public VerticalLine (
            Coord startPos,
            int length,
            bool withCorners,
            ConsoleColor color
        ) : base ( 
            startPos,
            length,
            withCorners,
            color
        ) { }

        public override List<Axel> Render() { 
            List<Axel> axelList = new List<Axel>();

            if (base.WithCorners) axelList.Add(new Axel(
                new Coord( base.StartPos.X, base.StartPos.Y, base.StartPos.Z ),
                CORNER, 
                base.Color
            ));
            
            for (
                int i = (base.WithCorners ? 1 : 0);
                i < (base.WithCorners ? base.Length - 1 : base.Length);
                i++
            ) { 
                axelList.Add(new Axel(
                    new Coord(
                        base.StartPos.X,
                        base.WithCorners ? base.StartPos.Y + i : base.StartPos.Y + i,
                        base.StartPos.Z
                    ),
                    V_LINE, 
                    base.Color
                ));
            }

            if (base.WithCorners) axelList.Add(new Axel(
                new Coord( 
                    base.StartPos.X, 
                    (base.StartPos.Y + base.Length) - 1, 
                    base.StartPos.Z
                ),
                CORNER,
                base.Color
            ));

            return axelList;
        }
    }
}