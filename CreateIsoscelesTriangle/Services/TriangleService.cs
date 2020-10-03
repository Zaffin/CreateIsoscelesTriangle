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
