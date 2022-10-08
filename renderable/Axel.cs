using Renderable.Primitives;

namespace Renderable { 
    public class Axel: IComparable { 
        public Axel ( 
            Coord pos,
            char c,
            ConsoleColor color
        ) { 
            Pos = new Coord(pos);
            C = c;
            Color = color;
        }

        public Axel(Axel axel) { 
            Pos = new Coord(axel.Pos);
            C = axel.C;
            Color = axel.Color;
        }
        
        public Coord Pos { get; }
        public char C { get; }
        public ConsoleColor Color { get; }

        public int CompareTo(object obj) { 
            int result = 0;

            if (obj == null) return 1;
            
            Axel other = obj as Axel;
            if (other == null) return 1;

            result = this.Pos.Y.CompareTo(other.Pos.Y);
            if (result != 0) return result;

            result = this.Pos.X.CompareTo(other.Pos.X);
            if (result != 0) return result;

            result = other.Pos.Z.CompareTo(this.Pos.Z);
            if (result != 0) return result;

            result = this.C.CompareTo(other.C);
            return result;
        }
    }
}