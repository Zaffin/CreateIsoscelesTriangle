using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mastercam.Math;

using CreateIsoscelesTriangle.DataTypes;

namespace CreateIsoscelesTriangle.Services
{
    public interface ITriangleService
    {
        bool CreateTriangle(Point3D origin,
                            TriangleBasePosition basePosition,
                            double width,
                            double height);

        IsoscelesTriangleDetails GetTriangleDetails(double width,
                                                    double height);

        Point3D SelectPoint(string prompt);
    }
}
