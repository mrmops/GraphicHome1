namespace WindowsFormsApp1._3DFigures
{
    public class Point3D
    {
        public double X;
        public double Y;
        public double Z;

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Matrix ToMatrix()
        {
            return new Matrix(new double[,]
            {
                {X},
                {Y},
                {Z},
                {1},
            });
        }

        public override string ToString()
        {
            return $"{X}, {Y}, {Z}";
        }
    }
}