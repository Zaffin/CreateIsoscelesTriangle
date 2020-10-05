using System;

using Mastercam.Math;
using Mastercam.Curves;
using Mastercam.IO;
using Mastercam.IO.Types;

namespace CreateIsoscelesTriangle.DataTypes
{
    public class IsoscelesTriangle
    {
        public Point3D Origin { get; set; }

        public TriangleBasePosition BasePosition { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double SideLength { get; set; }

        public IsoscelesTriangle(Point3D origin,
                                 TriangleBasePosition basePosition,
                                 double width,
                                 double height)
        {
            Origin = origin;
            BasePosition = basePosition;
            Width = width;
            Height = height;
            SideLength = Math.Sqrt(Math.Pow(height, 2) + Math.Pow(width / 2, 2));
        }

        public bool Draw()
        {
            switch (BasePosition)
            {
                case TriangleBasePosition.Top:
                    return CreateGeomertyFromBasePositionTop();

                case TriangleBasePosition.Left:
                    return CreateGeomertyFromBasePositionLeft();

                case TriangleBasePosition.Right:
                    return CreateGeomertyFromBasePositionRight();

                default:
                    return false;
            }
        }

        private bool CreateGeomertyFromBasePositionTop()
        {
            var topPoint = ViewManager.ConvertToViewCoordinates(Origin, ViewManager.CPlane);


            var basePointRight = new Point3D(topPoint.x - (Width / 2),
                                             topPoint.y - Height,
                                             topPoint.z);

            var basePointLeft = new Point3D(topPoint.x + (Width / 2),
                                            topPoint.y - Height,
                                            topPoint.z);

            topPoint = ViewManager.ConvertToWorldCoordinates(topPoint);
            basePointRight = ViewManager.ConvertToWorldCoordinates(basePointRight);
            basePointLeft = ViewManager.ConvertToWorldCoordinates(basePointLeft);

            var sideOne = new LineGeometry(basePointRight, topPoint);
            var sideTwo = new LineGeometry(basePointLeft, topPoint);
            var baseLine = new LineGeometry(basePointRight, basePointLeft);

            return CommitGeomerty(sideOne, sideTwo, baseLine);
        }

        private bool CreateGeomertyFromBasePositionLeft()
        {
            var basePointLeft = ViewManager.ConvertToViewCoordinates(Origin, ViewManager.CPlane);


            var basePointRight = new Point3D(basePointLeft.x + Width,
                                             basePointLeft.y,
                                             basePointLeft.z);

            var topPoint = new Point3D(basePointLeft.x + (Width / 2),
                                       basePointLeft.y + Height,
                                       basePointLeft.z);

            topPoint = ViewManager.ConvertToWorldCoordinates(topPoint);
            basePointRight = ViewManager.ConvertToWorldCoordinates(basePointRight);
            basePointLeft = ViewManager.ConvertToWorldCoordinates(basePointLeft);

            var sideOne = new LineGeometry(basePointRight, topPoint);
            var sideTwo = new LineGeometry(basePointLeft, topPoint);
            var baseLine = new LineGeometry(basePointRight, basePointLeft);

            return CommitGeomerty(sideOne, sideTwo, baseLine);
        }

        private bool CreateGeomertyFromBasePositionRight()
        {
            var basePointRight = ViewManager.ConvertToViewCoordinates(Origin, ViewManager.CPlane);


            var basePointLeft = new Point3D(basePointRight.x - Width,
                                            basePointRight.y,
                                            basePointRight.z);

            var topPoint = new Point3D(basePointRight.x - (Width / 2),
                                       basePointRight.y + Height,
                                       basePointRight.z);

            topPoint = ViewManager.ConvertToWorldCoordinates(topPoint);
            basePointRight = ViewManager.ConvertToWorldCoordinates(basePointRight);
            basePointLeft = ViewManager.ConvertToWorldCoordinates(basePointLeft);

            var sideOne = new LineGeometry(basePointRight, topPoint);
            var sideTwo = new LineGeometry(basePointLeft, topPoint);
            var baseLine = new LineGeometry(basePointRight, basePointLeft);

            return CommitGeomerty(sideOne, sideTwo, baseLine);
        }

        private bool CommitGeomerty(LineGeometry sideOne, LineGeometry sideTwo, LineGeometry baseLine)
        {
            try
            {
                sideOne.Commit();
                sideTwo.Commit();
                baseLine.Commit();

                return true;
            }
            catch (Exception Ex)
            {
                var message = $"{Ex.Message}\n{Ex.InnerException?.Message}";
                EventManager.LogEvent(MessageSeverityType.ErrorMessage, string.Empty, message);

                return false;
            }
        }

    }
}
