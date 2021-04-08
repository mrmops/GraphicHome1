using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp1._3DFigures;

namespace WindowsFormsApp1
{
    public static class Camera
    {
        private static Matrix _transform = Matrix.CreateStartMatrix()
                                           * Matrix.CreateRotationMatrixX(Math.PI / 2.4) 
                                           * Matrix.CreateRotationMatrixZ(Math.PI / 4);
        private static readonly Matrix DefaultTransform = Matrix.CreateStartMatrix() 
                                                 * Matrix.CreateRotationMatrixX(Math.PI / 3) 
                                                 * Matrix.CreateRotationMatrixZ(Math.PI / 3);

        public static Matrix GetTransform()
        {
            return _transform;
        }

        public static void MoveX(double dx)
        {
            _transform = _transform * Matrix.CreateTranslateMatrix(dx, 0, 0);
        }
        
        public static void MoveY(double dy)
        {
            _transform = _transform * Matrix.CreateTranslateMatrix(0, dy, 0);
        }
        
        public static void MoveZ(double dz)
        {
            _transform = _transform * Matrix.CreateTranslateMatrix(0, 0, dz);
        }

        public static void Scale(double scale)
        {
            _transform = _transform * Matrix.CreateScaleMatrix(scale);
        }
        
    }
}