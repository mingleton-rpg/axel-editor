namespace Engine { 
    namespace Renderable { 
        namespace Primitives { 
            public class Coord {
                public Coord ( 
                    int x, 
                    int y, 
                    int z
                ) { 
                    X = x;
                    Y = y;
                    Z = z;
                }

                public Coord (Coord coord) { 
                    X = coord.X;
                    Y = coord.Y;
                    Z = coord.Z;
                }

                public int X { get; }
                public int Y { get; }
                public int Z { get; }
            }
        }
    }
}