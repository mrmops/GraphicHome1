using System.Drawing;
using WindowsFormsApp1._3DFigures;

namespace WindowsFormsApp1
{
    // public class Line3DFactory: DrawableFactory<Line3D>
    // {
    //     private Point3DInput _point3DStartInput = new Point3DInput("Трехмерная точка начала x,y,z");
    //     private Point3DInput _point3DEndInput = new Point3DInput("Трехмерная точка конца x,y,z");
    //     private ColorInput _colorInput = new ColorInput("Цвет рисования");
    //     private IntInput _widthInput = new IntInput("Ширина рисования");
    //     protected override IInput[] Inputs => new IInput[] {_point3DStartInput, _point3DEndInput, _colorInput, _widthInput};
    //     public override string Name => "Трехмерная линия";
    //     protected override Line3D CreateDrawable()
    //     {
    //         return new Line3D(_point3DStartInput.Value, _point3DEndInput.Value, _colorInput.Value, _widthInput.Value);
    //     }
    // }
}