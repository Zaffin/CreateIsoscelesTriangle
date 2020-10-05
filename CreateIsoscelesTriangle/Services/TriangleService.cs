using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mastercam.IO;
using Mastercam.Math;

using CreateIsoscelesTriangle.DataTypes;

namespace CreateIsoscelesTriangle.Services
{
    public class TriangleService : ITriangleService
    {
        public bool CreateTriangle(Point3D origin, TriangleBasePosition basePosition, double width, double height)
        {
            var isoscelesTriangle = new IsoscelesTriangle(origin, basePosition, width, height);

            return isoscelesTriangle.Draw();
        }

        public IsoscelesTriangleDetails GetTriangleDetails(double width, double height)
        {
            var sideLength = Math.Sqrt(Math.Pow(height, 2) + Math.Pow(width / 2, 2));
            var halfWidth = width / 2;

            var aera = halfWidth * height;
            var perimeter = (sideLength * 2) + width;

            var baseAngle = Math.Asin(height / sideLength) * (180 / Math.PI);
            var vertexAngle = (Math.Asin(halfWidth / sideLength) * 2) * (180 / Math.PI);

            var inscribedRadius = ((sideLength * width * 2) - Math.Pow(width, 2)) / (height * 4);
            var circumscribedRadius = Math.Pow(sideLength, 2) / (height * 2);

            return new IsoscelesTriangleDetails(aera,
                                                perimeter,
                                                baseAngle,
                                                vertexAngle,
                                                inscribedRadius,
                                                circumscribedRadius);
        }

        public Point3D SelectPoint(string prompt)
        {
            var myPoint = new Point3D();

            SelectionManager.AskForPoint(prompt,
                                         Mastercam.IO.Types.PointMask.Null,
                                         ref myPoint);

            PromptManager.Clear();

            return myPoint;
        }
    }
}
